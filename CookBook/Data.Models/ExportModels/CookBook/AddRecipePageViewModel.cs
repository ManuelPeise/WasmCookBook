using Data.Models.UI;

namespace Data.Models.ExportModels.CookBook
{
    public class AddRecipePageViewModel
    {
        public List<string> RecipeNames { get; set; } = new List<string>();
        public List<DropDownItem> RecipeCategories { get; set; } = new List<DropDownItem>();
        public List<DropDownItem> IngredientCategories { get; set; } = new List<DropDownItem>();
        public List<DropDownItem> Units { get; set; } = new List<DropDownItem>();
        
    }
}
