using Data.AppContext;
using Data.Models.ExportModels.CookBook;
using Logic.CookBook;
using Logic.CookBook.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.CookBook
{
    // https://localhost:7032/api/CookBook/

    public class CookBookController: ApiControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICookBookUnitOfWork _cookBookUnitOfWork;

        public CookBookController(AppDbContext context, ICookBookUnitOfWork cookBookUnitOfWork)
        {
            _context = context;
            _cookBookUnitOfWork = cookBookUnitOfWork;
        }

        // GetRecipes?categoryId=1
        [HttpGet(Name = "GetRecipes")]
        public async Task<List<RecipeModel>> GetRecipes([FromQuery] int? categoryId = null)
        {
            using(var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.GetRecipes(categoryId);
            }
        }

        // GetRecipeCategories
        [HttpGet(Name = "GetRecipeCategories")]
        public async Task<List<CategoryModel>> GetRecipeCategories()
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.GetRecipeCategories();
            }
        }

        // GetIngredients
        [HttpGet(Name = "GetIngredients")]
        public async Task<List<IngredientModel>> GetIngredients()
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.GetIngredients();
            }
        }
    }
}
