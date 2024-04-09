using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.AppContext.Migrations
{
    /// <inheritdoc />
    public partial class ExtendRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Recipes",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Recipes");
        }
    }
}
