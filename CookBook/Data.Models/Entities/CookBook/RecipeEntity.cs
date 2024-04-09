using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Entities.CookBook
{
    public class RecipeEntity: AEntity
    {
        public int RecipeId => Id;
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public int FKCategoryId { get; set; }
        [ForeignKey(nameof(FKCategoryId))]
        public virtual CategoryEntity Category { get; set; } = new CategoryEntity();
        public ICollection<RecipeIngredientEntity> RecipeIngredients { get; set; } = new List<RecipeIngredientEntity>();
    }
}
