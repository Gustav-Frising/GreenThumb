using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{

    internal class GreenThumbDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public GreenThumbDbContext()
        {
            _provider = new GenerateEncryptionProvider("oooooooooooooooooooooooo");
        }
        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<PlantGardenModel> PlantGardens { get; set; }
        public DbSet<UserModel> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryption(_provider);


            modelBuilder.Entity<PlantGardenModel>().HasKey(pg => new { pg.PlantId, pg.GardenId });


            modelBuilder.Entity<PlantModel>()
                .HasData(new PlantModel()
                {
                    PlantId = 1,
                    Name = "Fire lilly",
                    Description = "The flower reaches on average 20–90 centimetres,They are hermaphroditic and scentless,",
                    PlantedDate = DateTime.Now,

                },
                new PlantModel()
                {
                    PlantId = 2,
                    Name = "Jade vine",
                    Description = "It has thick stems up to 2 cm in diameter, which it uses to crawl up tall trees to reach sunlight,the flowers hang like clusters of grapes ",
                    PlantedDate = DateTime.Now,

                },
                new PlantModel()
                {
                    PlantId = 3,
                    Name = "Magnolia",
                    Description = "Magnolias are spreading evergreen,haracterised by large fragrant flowers, which may be bowl-shaped or star-shaped",
                    PlantedDate = DateTime.Now,

                },
                new PlantModel()
                {
                    PlantId = 4,
                    Name = "Monkey face orchid",
                    Description = "Flowers are fragrant with the scent of a ripe orange and strongly resembles a monkey's face",
                    PlantedDate = DateTime.Now,

                },
            new PlantModel()
            {
                PlantId = 5,
                Name = "Parrot flower",
                Description = "The plant rows compactly to a height of about half a metre, its flower resemble that of a flying cockatoo",
                PlantedDate = DateTime.Now,

            });
            modelBuilder.Entity<InstructionModel>()
                .HasData(new InstructionModel()
                {
                    InstructionId = 1,
                    instructionText = "water plant",
                    PlantId = 1,
                },
                new InstructionModel()
                {
                    InstructionId = 2,
                    instructionText = "prefer calcareous soils",
                    PlantId = 1,
                },
                new InstructionModel()
                {
                    InstructionId = 3,
                    instructionText = "water plant",
                    PlantId = 2,
                },
                new InstructionModel()
                {
                    InstructionId = 4,
                    instructionText = "needs a minimum temperature of 15 °C",
                    PlantId = 2,
                },
                new InstructionModel()
                {
                    InstructionId = 5,
                    instructionText = "water plant",
                    PlantId = 3,
                },
                new InstructionModel()
                {
                    InstructionId = 6,
                    instructionText = "needs Pruning",
                    PlantId = 3,
                },
                new InstructionModel()
                {
                    InstructionId = 7,
                    instructionText = "water plant",
                    PlantId = 4,
                },
                new InstructionModel()
                {
                    InstructionId = 8,
                    instructionText = "needs a Light place in full shade",
                    PlantId = 4,
                });

            modelBuilder.Entity<UserModel>()
               .HasData(new UserModel()
               {
                   UserId = 1,
                   Username = "bob",
                   password = "Ross"
               });

        }
    }
}
