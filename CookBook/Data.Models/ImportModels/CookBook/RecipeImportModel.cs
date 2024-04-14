using Data.Models.ImportModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.ImportModels.CookBook
{
    public class RecipeImportModel: IRecipeImportModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Required]
        public RecipeCategoryImportModel RecipeCategory { get; set; } = new RecipeCategoryImportModel();
        [Required]
        public List<RecipeIngredientImportModel> Ingredients { get; set; } = new List<RecipeIngredientImportModel>();

        public bool IsValidModel()
        {
            return !string.IsNullOrWhiteSpace(Title) &&
                !string.IsNullOrWhiteSpace(ShortDescription) &&
                !string.IsNullOrWhiteSpace(Description) &&
                RecipeCategory.CategoryId != 0 &&
                Ingredients.Any();
        }
    }

    public class RecipeCategoryImportModel
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class RecipeIngredientImportModel
    {
        [Required, MinLength(2)]
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [Required, Range(1, 1000, ErrorMessage = "The Amount field is required.")]
        public decimal Amount { get; set; }
        public int UnitId { get; set; }
        [Required, MinLength(1)]
        public string Unit { get; set; } = string.Empty;
    }
}
