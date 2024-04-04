using Data.Models.Entities.CookBook;
using Data.Models.ExportModels.CookBook;

namespace Logic.CookBook.Extensions
{
    internal static class RecipeExtensions
    {
        internal static RecipeModel ToUiModel(this RecipeEntity entity, List<RecipeIngredientModel>? ingredients = null)
        {
            return new RecipeModel
            {
                RecipeId = entity.RecipeId,
                Title = entity.Title,
                ShortDescription = entity.ShortDescription,
                Description = entity.Description,
                Image = entity.Image,
                Ingredients = ingredients ?? new List<RecipeIngredientModel>()
            };
        }

        internal static CategoryModel ToUiModel(this CategoryEntity entity)
        {
            return new CategoryModel
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                CategoryType = entity.CategoryType,
            };
        }

        internal static IngredientModel ToUiModel(this IngredientEntity entity)
        {
            return new IngredientModel
            {
                IngredientId = entity.IngredientId,
                CategoryId = entity.FkCategoryId,
                Name = entity.Name
            };
        }

        internal static RecipeIngredientModel ToUiModel(this RecipeIngredientEntity entity, string name, CategoryModel category)
        {
            return new RecipeIngredientModel
            {
                RecipeIngredientId = entity.RecipeIngredientId,
                IngredientId = entity.IngredientId,
                Amount = entity.Amount,
                Category = category,
                Name = name,
                Unit = entity.Unit,
            };
        }

    }
}
