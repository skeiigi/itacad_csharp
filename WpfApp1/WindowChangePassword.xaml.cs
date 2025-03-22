using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowChangePassword.xaml
    /// </summary>
    public partial class WindowChangePassword : Window
    {
        private readonly int _userId;
        public WindowChangePassword(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = txtCurrentPassword.Password;
            string newPassword = txtNewPassword.Password;
            string confirmNewPassword = txtConfirmNewPassword.Password;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                using(var context = new ITAcademy1Entities())
                {
                    var user = context.Users.FirstOrDefault(u => u.id == _userId);

                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (user.password != currentPassword)
                    {
                        MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    user.password = newPassword;
                    user.isFirstLogin = false;

                    context.SaveChanges();
                    MessageBox.Show("Пароль успешно изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }
    }
}