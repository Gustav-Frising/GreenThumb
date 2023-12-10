using System.Windows;
using GreenThumb.Database;
using GreenThumb.Models;

namespace GreenThumb.Managers
{
    public static class Usermanager
    {
        public static UserModel? SignedInUser { get; set; }

        public static async Task<bool> AddUser(UserModel user)
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
        public static async Task<bool> ValidateUser(string username)
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
        public static async Task<bool> SignInUser(string username, string password)
        {
            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var users = uow.UserRepository.GetAll();

                foreach (var user in await users)
                {
                    if (user.Username == username && user.password == password)
                    {
                        Usermanager.SignedInUser = user;

                        return true;
                    }
                }
                return false;
            }
        }
        public static void SignOutUser()
        {
            Usermanager.SignedInUser = null;
        }

    }
}



