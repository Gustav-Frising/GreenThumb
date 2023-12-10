using System.Windows;
using System.Windows.Controls;
using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public int _plantId;


        public PlantDetailsWindow(int id)
        {
            _plantId = id;

            InitializeComponent();


            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {

                var selectedPlant = context.Plants.Include(p => p.Instructions).FirstOrDefault(p => p.PlantId == id);
                txtPlant.Text = selectedPlant?.Name;
                txtDescription.Text = selectedPlant?.Description;

                lstInstructions.Items.Clear();

                if (selectedPlant != null)
                {
                    foreach (var instruction in selectedPlant.Instructions)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Tag = instruction;
                        item.Content = instruction.instructionText;
                        lstInstructions.Items.Add(item);
                    }
                }
            }
        }
        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new();
            plantWindow.Show();
            Close();
        }

        private async void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {


            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {
                GreenThumbUow uow = new GreenThumbUow(context);


                var plantGardens = await uow.PlantGardenRepository.GetAll();

                var gardens = await uow.GardenRepository.GetAll();

                var userGarden = gardens.FirstOrDefault(g => g.UserId == Usermanager.SignedInUser.UserId);

                GardenManager.CurrentGarden = userGarden;


                //check if user has a garden

                if (userGarden != null)
                {

                    //check if user already has This plant
                    if (!userGarden.PlantGardens.Any(pg => pg.PlantId == _plantId))
                    {
                        PlantGardenModel plantgarden = new PlantGardenModel
                        {
                            PlantId = _plantId,
                            GardenId = userGarden.GardenId,
                        };

                        await uow.PlantGardenRepository.Add(plantgarden);
                        await uow.Complete();

                        PlantWindow PlantWindow = new();
                        PlantWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"you already have that plant in your garden");
                    }
                }
                else
                {
                    MessageBox.Show("User doesn't have a matching garden.");
                    AddGardenwindow addGadenWindow = new();

                    addGadenWindow.Show();

                    Close();
                }
            }


        }
    }
}
