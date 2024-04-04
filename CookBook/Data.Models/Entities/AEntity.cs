using System.ComponentModel.DataAnnotations;

namespace Data.Models.Entities
{
    public abstract class AEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
