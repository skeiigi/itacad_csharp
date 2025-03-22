using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistrationUser windowRegistrationUser = new WindowRegistrationUser();
            windowRegistrationUser.ShowDialog();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            using (var context = new ITAcademy1Entities())
            {
                var users = await context.Users.ToListAsync();
                Users.ItemsSource = users;
            }
        }

        private async void BtnUnlock_Click(object sender, RoutedEventArgs e)
        {
            if (Users.SelectedItem is Users selectedUser)
            {
                using (var context = new ITAcademy1Entities())
                {
                    var users = await context.Users.FindAsync(selectedUser.id);

                    if (users != null)
                    {
                        users.isLocked = false;
                        users.LastLoginDate = null;
                        await context.SaveChangesAsync();
                        LoadUsers();
                        MessageBox.Show("Пользователь разблокирован", "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя", "Важно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ITAcademy1Entities())
            {
                foreach (var user in Users.ItemsSource as IEnumerable<Users>)
                {
                    var existingUser = await context.Users.FindAsync(user.id);
                    if (existingUser != null)
                    {
                        existingUser.lastname = user.lastname;
                        existingUser.firstname = user.firstname;
                        existingUser.role = user.role;
                        existingUser.username = user.username;
                        existingUser.isLocked = user.isLocked;
                    }
                }
                await context.SaveChangesAsync();
                LoadUsers();
                MessageBox.Show("Изменения сохранены", "Успех");
            }
        }
    }
}