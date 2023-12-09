using System.Windows;
using System.Windows.Controls;
using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        public PlantWindow()
        {
            InitializeComponent();
            UpdateUi();
        }
        private async Task UpdateUi()
        {
            lstFlowers.Items.Clear();

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var plants = uow.PlantRepository.GetAll();

                foreach (var plant in await plants)
                {
                    ListViewItem item = new();
                    item.Content = plant.Name;
                    item.Tag = plant;
                    lstFlowers.Items.Add(item);
                }
                txtPlant.Text = "";

            }

        }
        private void btnAddFlower_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new();
            addPlantWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstFlowers.SelectedItem;

            PlantModel selectedPlant = (PlantModel)selectedItem.Tag;


            PlantDetailsWindow plantDetailsWindow = new(selectedPlant.PlantId);
            plantDetailsWindow.Show();
            Close();
        }


        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstFlowers.SelectedItem;
            if (selectedItem != null)
            {
                PlantModel selectedPlant = (PlantModel)selectedItem.Tag;
                lstFlowers.Items.Remove(selectedItem);

                using (GreenThumbDbContext context = new())
                {
                    GreenThumbUow uow = new(context);

                    await uow.PlantRepository.Delete(selectedPlant.PlantId);
                    await uow.Complete();
                }
                await UpdateUi();
            }
        }

        private void txtPlant_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUow uow = new GreenThumbUow(context);

                lstFlowers.Items.Clear();

                var plants = context.Plants.Where(p => p.Name.ToLower().StartsWith(txtPlant.Text.ToLower()))
                    .ToList();

                foreach (var plant in plants)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    lstFlowers.Items.Add(item);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUow uow = new GreenThumbUow(context);
                uow.SignOutUser();


                LoginWindow loginWindow = new();
                loginWindow.Show();

                Close();
            }
        }

        private async void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUow uow = new(context);
                var gardens = await uow.GardenRepository.GetAll();

                foreach (var garden in gardens)
                {
                    MessageBox.Show($"Checking garden: {garden.GardenId}, User: {garden.UserId}");

                    if (garden.UserId == Usermanager.SignedInUser.UserId)
                    {
                        MessageBox.Show($"User's garden found: {garden.GardenId}");
                        Usermanager.CurrentGarden = garden;
                        break;
                    }
                }
                MyGardenWindow gardenWindow = new(Usermanager.CurrentGarden.GardenId);

                gardenWindow.Show();

                Close();
            }
        }

        private void btnAddGarden_Click(object sender, RoutedEventArgs e)
        {
            AddGardenwindow addGadenWindow = new();

            addGadenWindow.Show();

            Close();
        }
    }
}

