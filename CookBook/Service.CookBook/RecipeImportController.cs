using Data.AppContext;
using Logic.CookBook.Interfaces;
using Service.Shared;

namespace Service.CookBook
{
    public class RecipeImportController: ApiControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICookBookUnitOfWork _cookBookUnitOfWork;

        public RecipeImportController(AppDbContext context, ICookBookUnitOfWork cookBookUnitOfWork)
        {
            _context = context;
            _cookBookUnitOfWork = cookBookUnitOfWork;
        }
    }
}
