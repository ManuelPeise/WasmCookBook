using Data.Models.ImportModels.CookBook;

namespace Data.Models.ImportModels.Interfaces
{
    public interface IRecipeImportModel
    {
        string Title { get; set; }
        string ShortDescription { get; set; }
        string Description { get; set; }
        string Image { get; set; }
        RecipeCategoryImportModel RecipeCategory { get; set; }
        List<RecipeIngredientImportModel> Ingredients { get; set; }
    }
}
