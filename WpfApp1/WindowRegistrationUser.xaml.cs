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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistrationUser.xaml
    /// </summary>
    public partial class WindowRegistrationUser : Window
    {
        public WindowRegistrationUser()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            using (var context = new ITAcademy1Entities())
            {
                var roles = context.Roles.ToList();

                var SelectedRole = roles.Select(r => new
                {
                    r.role,
                }).ToList();

                roleUser.ItemsSource = SelectedRole;
                roleUser.DisplayMemberPath = "role";
            }
        }

        private void BtnNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtLastname.Text == null || txtFirstname.Text == null || txtUsername.Text == null || txtPassword.Password == null)
            {
                MessageBox.Show("Заполните обязательные поля!", "Ошибка");
            }
            try
            {
                using (var context = new ITAcademy1Entities())
                {
                    var user = new Users()
                    {
                        lastname = txtLastname.Text,
                        firstname = txtFirstname.Text,
                        username = txtUsername.Text,
                        password = txtPassword.Password,
                        phone = txtPhone.Text,
                        role = int.Parse(roleUser.Text),
                    };

                    //var userr = context.Users
                    //    .Where(u => u.password == user.password)
                    //    .FirstOrDefault();

                    //if (userr != null)
                    //{
                    //    MessageBox.Show($"Такой пароль уже есть у пользователя {userr.username}");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Пользователь успешно добавлен", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    //    //context.Users.Add(user);
                    //    //context.SaveChanges();
                    //    //Close();
                    //}

                    var userr = context.Users
                        .Where(u => u.username == user.username)
                        .FirstOrDefault();

                    if (userr != null)
                    {
                        MessageBox.Show("Пользователь с таким именем уже есть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь успешно добавлен", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        context.Users.Add(user);
                        context.SaveChanges();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}");
            }
        }
    }
}
