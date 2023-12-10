using System.Windows;
using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for AddGardenwindow.xaml
    /// </summary>
    public partial class AddGardenwindow : Window
    {
        public AddGardenwindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow PlantWindow = new();
            PlantWindow.Show();
            Close();
        }

        //add garden to user
        private async void btnaddGarden_Click(object sender, RoutedEventArgs e)
        {
            string location = txtGardenLocation.Text;

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new GreenThumbUow(context);

                var user = Usermanager.SignedInUser;

                GardenModel newGarden = new()
                {
                    Location = location,
                    UserId = user.UserId
                };
                await uow.GardenRepository.Add(newGarden);
                await uow.Complete();
            }

            PlantWindow PlantWindow = new();
            PlantWindow.Show();
            Close();
        }
    }
}

