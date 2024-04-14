namespace Data.Models.Entities.CookBook
{
    public class RecipeImportEntity: AEntity
    {
        public string Json { get; set; } = string.Empty;
        public string RecipeName { get; set; } = string.Empty;
        public bool ImportFinished { get; set; }
        public DateTime ImportedAt { get; set; }
        public DateTime? ImportFinishedAt { get; set; }
    }
}
