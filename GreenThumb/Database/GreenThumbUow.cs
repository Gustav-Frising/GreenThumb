using System.Windows;
using GreenThumb.Managers;
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
        public async Task<bool> AddUser(UserModel user)
        {
            if (await ValidateUser(user.Username))
            {
                UserModel newuser = new()
                {
                    Username = user.Username,
                    password = user.password

                };

                if (string.IsNullOrWhiteSpace(user.password))
                {
                    MessageBox.Show("Must add a password");
                    return false;
                }
                using (GreenThumbDbContext context = new())
                {
                    GreenThumbUow uow = new(context);

                    await uow.UserRepository.Add(newuser);
                    await uow.Complete();
                }

                return true;
            }
            return false;
        }
        public async Task<bool> ValidateUser(string username)
        {
            bool isValidUSername = true;

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var users = uow.UserRepository.GetAll();

                foreach (var user in await users)
                {
                    if (user.Username == username)
                    {
                        isValidUSername = false;
                    }
                }
                return isValidUSername;
            }
        }
        public async Task<bool> SignInUser(string username, string password)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var users = uow.UserRepository.GetAll();

                foreach (var user in await users)
                {
                    if (user.Username == username && user.password == password)
                    {
                        //user was found
                        Usermanager.SignedInUser = user;

                        return true;
                    }
                }
                return false;
            }
        }
        public void SignOutUser()
        {
            Usermanager.SignedInUser = null;
        }

    }
}
