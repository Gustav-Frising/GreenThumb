using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime PlantedDate { get; set; }
        public List<InstructionModel> Instructions { get; set; } = new();
        public List<PlantGardenModel> PlantGardens { get; set; } = new();
    }
}
