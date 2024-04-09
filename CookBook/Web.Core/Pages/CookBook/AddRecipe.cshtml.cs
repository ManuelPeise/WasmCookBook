using Data.Models.ExportModels.CookBook;
using Data.Models.ImportModels.CookBook;
using Logic.CookBook.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Resources;

namespace Web.Core.Pages.CookBook
{
    public class AddRecipeModel : PageModel
    {
        private readonly ICookBookUnitOfWork _cookbookUnitOfWork;

        private const string _nameSpace = ResourceHandler.ResxCookBook;
        [BindProperty]
        public List<CategoryModel> RecipeCategories { get; set; } = new List<CategoryModel>();

        [BindProperty]
        public string NameSpace { get => _nameSpace; }
        [BindProperty]
        public ResourceHandler ResourceHandler { get; set; }

        [BindProperty]
        public RecipeImportModel RecipeModel { get; set; } = new RecipeImportModel();
        [BindProperty]
        public RecipeCategoryImportModel Caregory { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; } 
        
        public AddRecipeModel(ICookBookUnitOfWork cookbookUnitOfWork)
        {
            _cookbookUnitOfWork = cookbookUnitOfWork;
            ResourceHandler = new ResourceHandler();
        }

        public async Task OnPost()
        {
            var recipe = RecipeModel;
        }

        public async Task OnGet()
        {
            RecipeCategories = await _cookbookUnitOfWork.GetRecipeCategories();

            ResourceHandler = new ResourceHandler();
        }

    }
}
