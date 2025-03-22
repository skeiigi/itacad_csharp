using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string GetMD5(string value)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                // Преобразуем входную строку в массив байтов
                var data = Encoding.UTF8.GetBytes(value);

                // Вычисляем хеш
                var hashBytes = provider.ComputeHash(data);

                // Преобразуем хеш в шестнадцатеричное представление
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // "x2" означает шестнадцатеричное представление с двумя символами
                }

                return sb.ToString(); // Возвращаем строку в формате hex
            }
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = GetMD5(txtPassword.Password);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль");
                return;
            }
            using (var context = new ITAcademy1Entities())
            {
                var user = await context.Users
                    .Where(u => u.username == username)
                    .FirstOrDefaultAsync();
                if (user == null)
                {
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (user.isLocked.HasValue && user.isLocked.Value)
                {
                    MessageBox.Show("Вы заблокированы, обратитесь к администратору", "Доступ заблокирован", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (user.LastLoginDate.HasValue && (DateTime.Now - user.LastLoginDate.Value).TotalDays > 30 && user.role != 2)
                {
                    user.isLocked = true;
                    await context.SaveChangesAsync();
                    MessageBox.Show("Ваша учетная запись заблокирована из-за длительного отсутствия", "Доступ запрещен", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (user.password == password)
                {
                    user.LastLoginDate = DateTime.Now;
                    user.FailedLoginAttempts = 0;
                    await context.SaveChangesAsync();
                    MessageBox.Show("Вы успешно авторизовались", "Добро пожаловать", MessageBoxButton.OK, MessageBoxImage.Information);
                    

                    if (user.isFirstLogin.HasValue && user.isFirstLogin.Value)
                    {
                        WindowChangePassword windowChangePassword = new WindowChangePassword(user.id);
                        windowChangePassword.Owner = this;
                        windowChangePassword.ShowDialog();
                    }
                    else
                    {
                        if (user.role == 2)
                        {
                            WindowAdmin windowAdmin = new WindowAdmin();
                            windowAdmin.ShowDialog();
                        }
                        else if (user.role == 3)
                        {
                            WindowHotelAdmin windowHotelAdmin = new WindowHotelAdmin();
                            windowHotelAdmin.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Вы вошли и хватит", "Успех");
                        }
                        Close();
                    }
                }
                else
                {
                    user.FailedLoginAttempts++;
                    if(user.FailedLoginAttempts == 3)
                    {
                        user.isLocked = true;
                        MessageBox.Show("Вы заблокированы после 3 неудачных попыток входа", "Доступ запрещен", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        int attemptsLeft = 3 - (user.FailedLoginAttempts ?? 0);
                        MessageBox.Show($"Неправильный логин или пароль. Осталось попыток: {attemptsLeft}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    await context.SaveChangesAsync();
                }
            }
            
        }

        private void MainWindow_activated(object sender, EventArgs e)
        {
            using (var context = new ITAcademy1Entities())
            {
                var users = context.Users.ToList();

                foreach (var user in users)
                {
                    // Проверяем, является ли пароль уже хешем (например, длина хеша MD5 = 32 символа)
                    if (user.password.Length != 32 || !IsHex(user.password))
                    {
                        user.password = GetMD5(user.password);
                    }
                }

                context.SaveChanges();
            }
        }

        // Метод для проверки, является ли строка шестнадцатеричной
        private bool IsHex(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}