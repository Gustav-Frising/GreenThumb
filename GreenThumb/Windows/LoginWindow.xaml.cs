using System.Windows;
using GreenThumb.Database;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new();
            registrationWindow.Show();
            Close();
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                GreenThumbUow uow = new GreenThumbUow(context);

                bool isSuccessfulSignIn = await uow.SignInUser(username, password);

                if (isSuccessfulSignIn)
                {
                    PlantWindow plantWindow = new();
                    plantWindow.Show();
                    Close();
                }
                else
                {

                    MessageBox.Show("Invalid username or password!, Warning");
                }
            }
        }
    }
}
