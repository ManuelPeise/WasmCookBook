namespace Data.Models.ExportModels.CookBook
{
    public class IngredientModel
    {
        public int IngredientId {  get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
