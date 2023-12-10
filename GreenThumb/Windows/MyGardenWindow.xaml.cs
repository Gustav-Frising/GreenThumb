using System.Windows;
using System.Windows.Controls;
using GreenThumb.Database;
using GreenThumb.Managers;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>
    public partial class MyGardenWindow : Window
    {
        public MyGardenWindow(int id)
        {
            InitializeComponent();

            txtlocation.Text = GardenManager.CurrentGarden.Location;
            txtGarden.Text = ($"{Usermanager.SignedInUser.Username}'s Garden");

            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUow uow = new GreenThumbUow(context);


                var selectedPlants = context.PlantGardens
                    .Include(pg => pg.Plant)
                    .Where(p => p.GardenId == id)
                    .ToList();

                lstGardenPlants.Items.Clear();
                foreach (var plant in selectedPlants)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = plant;
                    item.Content = plant.Plant.Name;
                    lstGardenPlants.Items.Add(item);
                }


            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow PlantWindow = new();
            PlantWindow.Show();
            Close();
        }
    }
}
