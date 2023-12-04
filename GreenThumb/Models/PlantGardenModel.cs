namespace GreenThumb.Models
{
    public class PlantGardenModel
    {
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;
        public int GardenId { get; set; }
        public GardenModel Garden { get; set; } = null!;


    }
}
