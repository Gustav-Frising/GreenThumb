using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class GardenModel
    {
        [Key]
        public int GardenId { get; set; }
        public string Location { get; set; } = null!;
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public List<PlantGardenModel> PlantGardens { get; set; } = new();
    }

}
