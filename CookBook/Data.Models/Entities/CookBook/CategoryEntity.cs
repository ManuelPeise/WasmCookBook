using Data.Models.Enums.CookBook;

namespace Data.Models.Entities.CookBook
{
    public class CategoryEntity : AEntity
    {
        public int CategoryId => Id;
        public string Name { get; set; } = string.Empty;
        public CategoryTypeEnum CategoryType { get; set; }
    }
}
