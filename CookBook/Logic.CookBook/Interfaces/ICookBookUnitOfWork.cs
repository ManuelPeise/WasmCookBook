using Data.Models.Entities.CookBook;
using Data.Models.ExportModels.CookBook;
using Data.Models.ImportModels.CookBook;
using Logic.Shared.Interfaces;

namespace Logic.CookBook.Interfaces
{
    public interface ICookBookUnitOfWork : IDisposable
    {
        public IRepositoryBase<RecipeEntity> RecipeRepository { get; }
        public IRepositoryBase<CategoryEntity> CategoryRepository { get; }
        public IRepositoryBase<IngredientEntity> IngredientRepository { get; }
        public IRepositoryBase<RecipeIngredientEntity> RecipeIngredientRepository { get; }
        public IRepositoryBase<UnitEntity> IngredientUnitRepository { get; }
        public IRepositoryBase<RecipeImportEntity> RecipeImportRepository { get; }

        Task<List<RecipeModel>> GetRecipes(int? categoryId);
        Task<List<IngredientModel>> GetIngredients();
        Task<List<CategoryModel>> GetCategories(bool isRecipeCategory);
        Task<List<UnitModel>> GetUnits();
        Task<List<RecipeRequestExportModel>> GetRecipeImports(bool importFinished = false);
        Task<bool> ImportRecipe(int id);
        Task<bool> ImportRecipeRequest(RecipeImportModel model);
        Task<bool> DeleteRecipeRequest(int id);
        Task DeleteRecipe(int recipeId);
    }
}
