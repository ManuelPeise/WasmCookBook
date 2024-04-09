using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Shared.ViewModels;

namespace Web.Core.Pages.CookBook
{
    public class CookBookIndexModel : PageModel
    {
        [BindProperty]
        public CookBookViewModel ViewModel { get; set; }

        public CookBookIndexModel(CookBookViewModel vm)
        {
            ViewModel = vm;
        }

        public void OnGet()
        {
        }
    }
}
