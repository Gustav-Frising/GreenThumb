using GreenThumb.Models;

namespace GreenThumb.Database
{
    internal class GreenThumbUow
    {

        private readonly GreenThumbDbContext _context;

        public GreenThumbRepository<GardenModel> GardenRepository { get; }
        public GreenThumbRepository<InstructionModel> InstructionRepository { get; }
        public GreenThumbRepository<PlantModel> PlantRepository { get; set; }
        public GreenThumbRepository<UserModel> UserRepository { get; set; }


        public GreenThumbUow(GreenThumbDbContext context)
        {
            _context = context;
            GardenRepository = new(context);
            InstructionRepository = new(context);
        }

    }
}
