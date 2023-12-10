using System.ComponentModel.DataAnnotations;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace GreenThumb.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        [EncryptColumn]
        public string password { get; set; } = null!;
        public GardenModel? Garden { get; set; }

    }
}
