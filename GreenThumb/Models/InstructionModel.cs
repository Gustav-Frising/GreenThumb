using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class InstructionModel
    {
        [Key]
        public int InstructionId { get; set; }
        public string instructionText { get; set; } = null!;
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;
    }
}
