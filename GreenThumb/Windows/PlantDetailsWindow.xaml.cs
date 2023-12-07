using System.Windows;
using System.Windows.Controls;
using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        int _plantId;
        public PlantDetailsWindow(int id)
        {

            InitializeComponent();


            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {

                var selectedPlant = context.Plants.Include(p => p.Instructions).FirstOrDefault(p => p.PlantId == id);
                txtPlant.Text = selectedPlant.Name;
                txtDescription.Text = selectedPlant.Description;

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

    }
}
