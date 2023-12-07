using System.Windows;
using GreenThumb.Database;
using GreenThumb.Models;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            Close();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUow uow = new GreenThumbUow(context);

                UserModel newUser = new();
                {
                    newUser.Username = txtUsername.Text;
                    newUser.password = txtPassword.Text;

                }

                bool isUserAdded = await uow.AddUser(newUser);
                if (isUserAdded)
                {
                    MessageBox.Show("user has been added sucessfully");
                    LoginWindow loginWindow = new();
                    loginWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("User could not be added");
                }
            }

        }
    }
}
