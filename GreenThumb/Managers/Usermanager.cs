using GreenThumb.Models;

namespace GreenThumb.Managers
{
    public static class Usermanager
    {
        public static UserModel? SignedInUser { get; set; }
        public static GardenModel? CurrentGarden { get; set; }
    }
}
