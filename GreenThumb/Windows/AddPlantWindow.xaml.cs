using System.Windows;
using System.Windows.Controls;
using GreenThumb.Database;
using GreenThumb.Models;

namespace GreenThumb.Windows
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public AddPlantWindow()
        {
            InitializeComponent();
        }

        private async void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            string name = txtPlant.Text;
            string details = txtPlantDetails.Text;
            DateTime date = DateTime.Now;

            List<InstructionModel> instructions = new();

            using (GreenThumbDbContext context = new())
            {
                foreach (string instruction in lstDescriptions.Items)
                {
                    InstructionModel newinstruction = new()
                    {
                        instructionText = instruction,

                    };

                    instructions.Add(newinstruction);
                }
                PlantModel newPlant = new()
                {
                    Name = name.ToLower(),
                    Description = details,
                    PlantedDate = date,
                    Instructions = instructions

                };
                GreenThumbUow uow = new(context);
                var flowers = await uow.PlantRepository.GetAll();
                var flowerExists = context.Plants.Any(p => p.Name.ToLower() == name.ToLower());

                if (!flowerExists)
                {
                    await uow.PlantRepository.Add(newPlant);
                    await uow.Complete();

                    PlantWindow PlantWindow = new();
                    PlantWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("plant already exist");
                    txtisntructions.Text = "";
                    txtPlant.Text = "";
                    txtPlantDetails.Text = "";
                }

            }


        }


        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //fixa exeption
            ListViewItem selectedItem = (ListViewItem)lstDescriptions.SelectedItem;
            if (selectedItem != null)
            {
                lstDescriptions.Items.Remove(selectedItem);
            }
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            string instruction = txtisntructions.Text;
            //ListViewItem item = new();
            //item.Content = instruction;
            //item.Tag = instruction;
            lstDescriptions.Items.Add(instruction);

            txtisntructions.Text = "";


        }

    }

}
