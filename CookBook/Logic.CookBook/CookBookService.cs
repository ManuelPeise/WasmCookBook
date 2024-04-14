using Data.AppContext;
using Data.Models.ExportModels.CookBook;
using Data.Models.ImportModels.CookBook;
using Data.Models.UI;
using Logic.CookBook.Interfaces;
using Logic.Shared;

namespace Logic.CookBook
{
    public class CookBookService : ALogicBase, IDisposable
    {
        private readonly ICookBookUnitOfWork _cookBookUnitOfWork;
       
        public CookBookService(AppDbContext dbContext, ICookBookUnitOfWork cookBookUnitOfWork) : base(dbContext)
        {
            _cookBookUnitOfWork = cookBookUnitOfWork;
        }

        public async Task<List<RecipeModel>> GetRecipes(int? categoryId = null)
        {
            return await _cookBookUnitOfWork.GetRecipes(categoryId);
        }

        public async Task<List<IngredientModel>> GetIngredients()
        {
            return await _cookBookUnitOfWork.GetIngredients();
        }

        public async Task<List<CategoryModel>> GetRecipeCategories()
        {
            return await _cookBookUnitOfWork.GetCategories(true);
        }

        public async Task<AddRecipePageViewModel> GetAddRecipePageModel()
        {
            var recipes = await GetRecipes();

            var recipeCategories = await _cookBookUnitOfWork.GetCategories(true);
            var ingredientCategories = await _cookBookUnitOfWork.GetCategories(false);
            var units = await _cookBookUnitOfWork.GetUnits();

            var model = new AddRecipePageViewModel
            {
                RecipeCategories = (from cat in recipeCategories select new DropDownItem { Id = cat.CategoryId, Value = cat.Name}).OrderBy(x => x.Value).ToList(),
                IngredientCategories = (from cat in ingredientCategories select new DropDownItem { Id = cat.CategoryId, Value = cat.Name }).OrderBy(x => x.Value).ToList(),
                Units = (from unit in units select new DropDownItem { Id = unit.UnitId, Value = unit.Name }).OrderBy(x => x.Value).ToList(),
                RecipeNames = recipes.Select(recipe => recipe.Title).OrderBy(x => x).ToList(),
            };

            return model;
        }

        public async Task<bool> ImportRecipe(RecipeImportModel model)
        {
            return await _cookBookUnitOfWork.ImportRecipeRequest(model);
        }

        //public async Task<bool> ImportRecipe(RecipeImportModel model)
        //{
        //    return await _cookBookUnitOfWork.ImportRecipe(model);
        //}

        #region dispose

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                   _cookBookUnitOfWork?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
