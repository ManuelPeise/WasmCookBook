using Data.Models.Entities.CookBook;
using Data.Models.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace Data.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        // Log
        public DbSet<LogMessageEntity> LogMessages { get; set; }

        // CookBook
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }

    }
}
