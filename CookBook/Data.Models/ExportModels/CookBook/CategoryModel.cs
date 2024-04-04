using Data.Models.Enums.CookBook;

namespace Data.Models.ExportModels.CookBook
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public CategoryTypeEnum CategoryType { get; set; }
    }
}
