using Data.AppContext;
using Data.Models.ImportModels.CookBook;
using Logic.CookBook;
using Logic.CookBook.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Shared;

namespace Service.CookBook
{
    public class RecipeImportController : ApiControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICookBookUnitOfWork _cookBookUnitOfWork;

        public RecipeImportController(AppDbContext context, ICookBookUnitOfWork cookBookUnitOfWork)
        {
            _context = context;
            _cookBookUnitOfWork = cookBookUnitOfWork;
        }

        //RecipeImport/ImportRecipe
        [HttpPost(Name = "ImportRecipe")]
        public async Task<bool> ImportRecipe()
        {
            
            using (var service = new CookBookService(_context, _cookBookUnitOfWork))
            {
                var model = await GetModelFromBody<RecipeImportModel>();

                return await service.ImportRecipe(model); ;
            }
        }
    }
}
