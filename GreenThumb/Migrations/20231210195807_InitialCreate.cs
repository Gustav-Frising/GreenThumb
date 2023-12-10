using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instructionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionId);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.GardenId);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantGardens",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantGardens", x => new { x.PlantId, x.GardenId });
                    table.ForeignKey(
                        name: "FK_PlantGardens_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantGardens_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Name", "PlantedDate" },
                values: new object[,]
                {
                    { 1, "The flower reaches on average 20–90 centimetres,They are hermaphroditic and scentless,", "Fire lilly", new DateTime(2023, 12, 10, 20, 58, 7, 251, DateTimeKind.Local).AddTicks(3048) },
                    { 2, "It has thick stems up to 2 cm in diameter, which it uses to crawl up tall trees to reach sunlight,the flowers hang like clusters of grapes ", "Jade vine", new DateTime(2023, 12, 10, 20, 58, 7, 251, DateTimeKind.Local).AddTicks(3117) },
                    { 3, "Magnolias are spreading evergreen,haracterised by large fragrant flowers, which may be bowl-shaped or star-shaped", "Magnolia", new DateTime(2023, 12, 10, 20, 58, 7, 251, DateTimeKind.Local).AddTicks(3120) },
                    { 4, "Flowers are fragrant with the scent of a ripe orange and strongly resembles a monkey's face", "Monkey face orchid", new DateTime(2023, 12, 10, 20, 58, 7, 251, DateTimeKind.Local).AddTicks(3123) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Username", "password" },
                values: new object[] { 1, "user", "BETzSRAPc3/w6srQ6jx5bw==" });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "PlantId", "instructionText" },
                values: new object[,]
                {
                    { 1, 1, "water plant" },
                    { 2, 1, "prefer calcareous soils" },
                    { 3, 2, "water plant" },
                    { 4, 2, "needs a minimum temperature of 15 °C" },
                    { 5, 3, "water plant" },
                    { 6, 3, "needs Pruning" },
                    { 7, 4, "water plant" },
                    { 8, 4, "needs a Light place in full shade" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_PlantId",
                table: "Instructions",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGardens_GardenId",
                table: "PlantGardens",
                column: "GardenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "PlantGardens");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
