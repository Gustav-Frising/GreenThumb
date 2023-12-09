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

        private async void btnaddGarden_Click(object sender, RoutedEventArgs e)
        {
            string location = txtGardenLocation.Text;
            bool hasGreenhouse = ((bool)cbGreenhouse.IsChecked);


            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new GreenThumbUow(context);

                var user = Usermanager.SignedInUser;

                GardenModel newGarden = new()
                {
                    Location = location,
                    Hasgreenhouse = hasGreenhouse,
                    UserId = user.UserId
                };

                Usermanager.SignedInUser.Garden = newGarden;
                await uow.GardenRepository.Add(newGarden);
                await uow.Complete();
            }

            PlantWindow PlantWindow = new();
            PlantWindow.Show();
            Close();
        }
    }
}

