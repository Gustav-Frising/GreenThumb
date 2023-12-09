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

                var gardens = await uow.GardenRepository.GetAll();

                foreach (var garden in gardens)
                {


                    if (garden.UserId == Usermanager.SignedInUser.UserId)
                    {

                        Usermanager.CurrentGarden = garden;
                        break;
                    }
                }

                if (Usermanager.CurrentGarden != null)
                {
                    PlantGardenModel plantgarden = new()
                    {
                        PlantId = _plantId,
                        GardenId = Usermanager.CurrentGarden.GardenId,
                    };

                    await uow.PlantGardenRepository.Add(plantgarden);
                    await uow.Complete();

                }
                else
                {
                    MessageBox.Show("User doesn't have a matching garden.");
                }
            }



            //using (GreenThumbDbContext context = new GreenThumbDbContext())
            //{
            //    GreenThumbUow uow = new GreenThumbUow(context);

            //    var gardens = await uow.GardenRepository.GetAll();

            //    var userGarden = gardens.FirstOrDefault(g => g.UserId == Usermanager.SignedInUser.UserId);

            //    if (userGarden != null)
            //    {
            //        PlantGardenModel plantgarden = new PlantGardenModel
            //        {
            //            PlantId = _plantId,
            //            GardenId = userGarden.GardenId,
            //        };

            //        await uow.PlantGardenRepository.Add(plantgarden);
            //        await uow.Complete();
            //    }

            //}


        }
    }
}
