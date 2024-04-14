using Data.AppContext.DataSeeds;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CookBookRecipeCategorySeed());
            modelBuilder.ApplyConfiguration(new IngredientUnitSeed());
        }

        // Log
        public DbSet<LogMessageEntity> LogMessages { get; set; }

        // CookBook
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<UnitEntity> IngredientUnits { get; set; }
        public DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }
        public DbSet<RecipeImportEntity> RecipeImports { get; set; }

    }
}
