using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Entities.CookBook
{
    public class IngredientEntity: AEntity
    {
        public int IngredientId => Id;
        public string Name { get; set; } = string.Empty;
        public int FkCategoryId { get; set; }
        [ForeignKey(nameof(FkCategoryId))]
        public virtual CategoryEntity? Category { get; set; }
        public ICollection<RecipeIngredientEntity>? RecipeIngredients { get; set; }
    }
}
