using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class GardenModel
    {
        [Key]
        public int GardenId { get; set; }
        public string location { get; set; } = null!;
        public bool Hasgreenhouse { get; set; }
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public List<PlantGardenModel> PlandGardens { get; set; } = new();
    }

}
