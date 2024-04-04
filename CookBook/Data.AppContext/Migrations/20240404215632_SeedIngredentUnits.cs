using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.AppContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedIngredentUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IngredientUnits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kg" },
                    { 2, "g" },
                    { 3, "Liter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
