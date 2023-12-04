using System.ComponentModel.DataAnnotations;

namespace GreenThumb.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string password { get; set; } = null!;
        public GardenModel? Garden { get; set; }

    }
}
