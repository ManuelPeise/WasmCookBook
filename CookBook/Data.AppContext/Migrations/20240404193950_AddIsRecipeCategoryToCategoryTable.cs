using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AppContext.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRecipeCategoryToCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecipeCategory",
                table: "Categories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecipeCategory",
                table: "Categories");
        }
    }
}
