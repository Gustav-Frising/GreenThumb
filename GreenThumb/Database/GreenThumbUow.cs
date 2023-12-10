using GreenThumb.Models;

namespace GreenThumb.Database
{
    internal class GreenThumbUow
    {

        private readonly GreenThumbDbContext _context;

        public GreenThumbRepository<GardenModel> GardenRepository { get; }
        public GreenThumbRepository<InstructionModel> InstructionRepository { get; }
        public GreenThumbRepository<PlantModel> PlantRepository { get; }
        public GreenThumbRepository<UserModel> UserRepository { get; }
        public GreenThumbRepository<PlantGardenModel> PlantGardenRepository { get; }

        public GreenThumbUow(GreenThumbDbContext context)
        {
            _context = context;
            GardenRepository = new(context);
            InstructionRepository = new(context);
            PlantRepository = new(context);
            UserRepository = new(context);
            PlantGardenRepository = new(context);
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();

        }
    }
}
