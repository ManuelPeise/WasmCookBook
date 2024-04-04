namespace Data.Models.ExportModels.CookBook
{
    public class RecipeIngredientModel
    {
        public int RecipeIngredientId { get; set; }
        public int IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public UnitModel Unit { get; set; } = new UnitModel();
        public CategoryModel Category { get; set; } = new CategoryModel();
    }
}
