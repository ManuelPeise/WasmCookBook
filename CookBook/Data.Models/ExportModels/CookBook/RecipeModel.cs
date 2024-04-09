namespace Data.Models.ExportModels.CookBook
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public List<RecipeIngredientModel> Ingredients { get; set; } = new List<RecipeIngredientModel>();
    }
}
