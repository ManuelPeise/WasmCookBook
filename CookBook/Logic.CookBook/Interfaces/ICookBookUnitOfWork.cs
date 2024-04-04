using Data.Models.Entities.CookBook;
using Data.Models.ExportModels.CookBook;
using Logic.Shared.Interfaces;

namespace Logic.CookBook.Interfaces
{
    public interface ICookBookUnitOfWork : IDisposable
    {
        public IRepositoryBase<RecipeEntity> RecipeRepository { get; }
        public IRepositoryBase<CategoryEntity> CategoryRepository { get; }
        public IRepositoryBase<IngredientEntity> IngredientRepository { get; }
        public IRepositoryBase<RecipeIngredientEntity> RecipeIngredientRepository { get; }

        Task<List<RecipeModel>> GetRecipes(int? categoryId);
        Task<List<IngredientModel>> GetIngredients();
        Task<List<CategoryModel>> GetRecipeCategories();
    }
}
