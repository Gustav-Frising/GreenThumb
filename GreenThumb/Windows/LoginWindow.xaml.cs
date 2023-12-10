using System.Windows;
using GreenThumb.Database;
using GreenThumb.Managers;

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
                GreenThumbUow uow = new(context);
                string username = txtUsername.Text;
                string password = txtPassword.Text;



                bool isSuccessfulSignIn = await Usermanager.SignInUser(username, password);


                if (isSuccessfulSignIn)
                {
                    // if user is found asign currentgarden to signedInUser
                    var gardens = await uow.GardenRepository.GetAll();
                    var userGarden = gardens.FirstOrDefault(g => g.UserId == Usermanager.SignedInUser.UserId);

                    GardenManager.CurrentGarden = userGarden;
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
