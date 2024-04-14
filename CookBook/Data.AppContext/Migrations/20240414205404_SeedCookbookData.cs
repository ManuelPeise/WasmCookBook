using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.AppContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedCookbookData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "IsRecipeCategory", "Name" },
                values: new object[,]
                {
                    { 1, 1, true, "Dessert" },
                    { 2, 1, true, "Huhn" },
                    { 3, 1, true, "Pasta" },
                    { 4, 1, true, "Rind" },
                    { 5, 1, true, "Schwein" },
                    { 6, 1, true, "Vegetarisch" },
                    { 7, 0, false, "Fisch" },
                    { 8, 0, false, "Fleisch" },
                    { 9, 0, false, "Gemüse" },
                    { 10, 0, false, "Obst" },
                    { 11, 0, false, "Getreideprodukte" },
                    { 12, 0, false, "Gewürze" }
                });

            migrationBuilder.InsertData(
                table: "IngredientUnits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kilo" },
                    { 2, "Gramm" },
                    { 3, "Liter" },
                    { 4, "Milliliter" },
                    { 5, "Stück" },
                    { 6, "Messerspitze" },
                    { 7, "Esslöffen" },
                    { 8, "Teelöffel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

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

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientUnits",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
