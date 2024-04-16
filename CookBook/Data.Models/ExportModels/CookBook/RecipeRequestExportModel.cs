namespace Data.Models.ExportModels.CookBook
{
    public class RecipeRequestExportModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public string TimeStamp { get; set; } = string.Empty;
        public RecipeRequest? Recipe { get; set; }
    }
}
