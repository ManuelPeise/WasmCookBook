using Data.Models.ImportModels.Interfaces;

namespace Data.Models.ImportModels.CookBook
{
    public class RecipeImportModel: IRecipeImportModel
    {
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public RecipeCategoryImportModel RecipeCategory { get; set; } = new RecipeCategoryImportModel();
        public List<RecipeIngredientImportModel> Ingredients { get; set; } = new List<RecipeIngredientImportModel>();
    }

    public class RecipeCategoryImportModel
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class RecipeIngredientImportModel
    {
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
