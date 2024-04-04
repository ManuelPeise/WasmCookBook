using Data.AppContext;
using Data.Models.ExportModels.CookBook;
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
            return await _cookBookUnitOfWork.GetRecipeCategories();
        }

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
