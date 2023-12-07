using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Name", "PlantedDate" },
                values: new object[,]
                {
                    { 1, "The flower reaches on average 20–90 centimetres,They are hermaphroditic and scentless,", "Fire lilly", new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3833) },
                    { 2, "It has thick stems up to 2 cm in diameter, which it uses to crawl up tall trees to reach sunlight,the flowers hang like clusters of grapes ", "Jade vine", new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3881) },
                    { 3, "Magnolias are spreading evergreen,haracterised by large fragrant flowers, which may be bowl-shaped or star-shaped", "Magnolia", new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3883) },
                    { 4, "Flowers are fragrant with the scent of a ripe orange and strongly resembles a monkey's face", "Monkey face orchid", new DateTime(2023, 12, 5, 11, 26, 45, 373, DateTimeKind.Local).AddTicks(3885) }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plants",
                keyColumn: "PlantId",
                keyValue: 4);
        }
    }
}
