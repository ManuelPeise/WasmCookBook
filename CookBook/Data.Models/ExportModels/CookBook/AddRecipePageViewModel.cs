namespace Data.Models.ExportModels.CookBook
{
    public class AddRecipePageViewModel
    {
        public List<CategoryModel> RecipeCategories { get; set; } = new List<CategoryModel>();
        public List<string> RecipeNames { get; set; } = new List<string>();
    }
}
