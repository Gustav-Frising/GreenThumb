﻿// <auto-generated />
using System;
using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(GreenThumbDbContext))]
    [Migration("20231205102645_seeddata")]
    partial class seeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Property<int>("GardenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GardenId"), 1L, 1);

                    b.Property<bool>("Hasgreenhouse")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GardenId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"), 1L, 1);

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<string>("instructionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructionId");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            InstructionId = 1,
                            PlantId = 1,
                            instructionText = "water plant"
                        },
                        new
                        {
                            InstructionId = 2,
                            PlantId = 1,
                            instructionText = "prefer calcareous soils"
                        },
                        new
                        {
                            InstructionId = 3,
                            PlantId = 2,
                            instructionText = "water plant"
                        },
                        new
                        {
                            InstructionId = 4,
                            PlantId = 2,
                            instructionText = "needs a minimum temperature of 15 °C"
                        },
                        new
                        {
                            InstructionId = 5,
                            PlantId = 3,
                            instructionText = "water plant"
                        },
                        new
                        {
                            InstructionId = 6,
                            PlantId = 3,
                            instructionText = "needs Pruning"
                        },
                        new
                        {
                            InstructionId = 7,
                            PlantId = 4,
                            instructionText = "water plant"
                        },
                        new
                        {
                            InstructionId = 8,
                            PlantId = 4,
                            instructionText = "needs a Light place in full shade"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.PlantGardenModel", b =>
                {
                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.HasKey("PlantId", "GardenId");

                    b.HasIndex("GardenId");

                    b.ToTable("PlantGardens");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlantedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PlantId");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            PlantId = 1,
                            Description = "The floweer xreaches on average 20–90 centimetres,They are hermaphroditic and scentless,",
                            Name = "Fire lilly",
                            PlantedDate = new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3833)
                        },
                        new
                        {
                            PlantId = 2,
                            Description = "It has thick stems up to 2 cm in diameter, which it uses to crawl up tall trees to reach sunlight,the flowers hang like clusters of grapes ",
                            Name = "Jade vine",
                            PlantedDate = new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3881)
                        },
                        new
                        {
                            PlantId = 3,
                            Description = "Magnolias are spreading evergreen,haracterised by large fragrant flowers, which may be bowl-shaped or star-shaped",
                            Name = "Magnolia",
                            PlantedDate = new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3883)
                        },
                        new
                        {
                            PlantId = 4,
                            Description = "Flowers are fragrant with the scent of a ripe orange and strongly resembles a monkey's face",
                            Name = "Monkey face orchid",
                            PlantedDate = new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3885)
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.HasOne("GreenThumb.Models.UserModel", "User")
                        .WithOne("Garden")
                        .HasForeignKey("GreenThumb.Models.GardenModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.HasOne("GreenThumb.Models.PlantModel", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantGardenModel", b =>
                {
                    b.HasOne("GreenThumb.Models.GardenModel", "Garden")
                        .WithMany("PlandGardens")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenThumb.Models.PlantModel", "Plant")
                        .WithMany("PlantGardens")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Navigation("PlandGardens");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Navigation("Instructions");

                    b.Navigation("PlantGardens");
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Navigation("Garden");
                });
#pragma warning restore 612, 618
        }
    }
}
