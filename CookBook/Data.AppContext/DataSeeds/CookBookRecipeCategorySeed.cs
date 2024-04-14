using Data.Models.Entities.CookBook;
using Data.Models.Enums.CookBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.AppContext.DataSeeds
{
    internal class CookBookRecipeCategorySeed : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasData(new List<CategoryEntity>
            {
                new CategoryEntity
                {
                     Id = 1,
                     Name = "Dessert",
                     CategoryType = CategoryTypeEnum.Recipe,
                     IsRecipeCategory = true,
                },
                new CategoryEntity
                {
                     Id = 2,
                     Name = "Huhn",
                     CategoryType = CategoryTypeEnum.Recipe,
                     IsRecipeCategory = true,
                },
                new CategoryEntity
                {
                     Id = 3,
                     Name = "Pasta",
                     CategoryType = CategoryTypeEnum.Recipe,
                     IsRecipeCategory = true,
                },
                 new CategoryEntity
                {
                     Id = 4,
                     Name = "Rind",
                     CategoryType = CategoryTypeEnum.Recipe,
                     IsRecipeCategory = true,
                },
                new CategoryEntity
                {
                     Id = 5,
                     Name = "Schwein",
                     CategoryType = CategoryTypeEnum.Recipe,
                     IsRecipeCategory = true,
                },
                new CategoryEntity
                {
                     Id = 6,
                     Name = "Vegetarisch",
                     CategoryType = CategoryTypeEnum.Recipe,
                     IsRecipeCategory = true,
                },
                new CategoryEntity
                {
                     Id = 7,
                     Name = "Fisch",
                     CategoryType = CategoryTypeEnum.Ingredient,
                     IsRecipeCategory = false,
                },
                new CategoryEntity
                {
                     Id = 8,
                     Name = "Fleisch",
                     CategoryType = CategoryTypeEnum.Ingredient,
                     IsRecipeCategory = false,
                },
                new CategoryEntity
                {
                     Id = 9,
                     Name = "Gemüse",
                     CategoryType = CategoryTypeEnum.Ingredient,
                     IsRecipeCategory = false,
                },
                new CategoryEntity
                {
                     Id = 10,
                     Name = "Obst",
                     CategoryType = CategoryTypeEnum.Ingredient,
                     IsRecipeCategory = false,
                },
                 new CategoryEntity
                {
                     Id = 11,
                     Name = "Getreideprodukte",
                     CategoryType = CategoryTypeEnum.Ingredient,
                     IsRecipeCategory = false,
                },
                new CategoryEntity
                {
                     Id = 12,
                     Name = "Gewürze",
                     CategoryType = CategoryTypeEnum.Ingredient,
                     IsRecipeCategory = false,
                },
            });
        }
    }
}
