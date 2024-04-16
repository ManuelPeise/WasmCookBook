using Data.AppContext;
using Data.Models.ExportModels.CookBook;
using Logic.CookBook;
using Logic.CookBook.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.CookBook
{
    // https://localhost:7053/api/CookBookAdministration/
    public class CookBookAdministrationController : ApiControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICookBookUnitOfWork _cookBookUnitOfWork;

        public CookBookAdministrationController(AppDbContext context, ICookBookUnitOfWork cookBookUnitOfWork)
        {
            _context = context;
            _cookBookUnitOfWork = cookBookUnitOfWork;
        }

        // api/CookBookAdministration/GetRecipeRequests/false
        [HttpGet("{isFinnished}", Name = "GetRecipeRequests")]
        public async Task<List<RecipeRequestExportModel>> GetRecipeRequests(bool isFinnished)
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.GetRecipeRequestModels(isFinnished);
            }
        }

        [HttpGet("{id}", Name = "ApproveRecipeRequest")]
        public async Task<List<RecipeRequestExportModel>> ApproveRecipeRequest(int Id)
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.ImportRecipe(Id);
            }
        }

        [HttpGet("{id}", Name = "RejectRecipeRequest")]
        public async Task<List<RecipeRequestExportModel>> RejectRecipeRequest(int id)
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.RejectRecipe(id);
            }
        }

        [HttpGet(Name = "GetExistingRecipes")]
        public async Task<List<RecipeInfoModel>> GetExistingRecipes()
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.GetExistingRecipes();
            }
        }

        [HttpGet("{recipeId}", Name = "DeleteRecipe")]
        public async Task<List<RecipeInfoModel>> DeleteRecipe(int recipeId)
        {
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                return await service.DeleteRecipe(recipeId);
            }
        }
    }
}
