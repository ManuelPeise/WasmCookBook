namespace Data.Models.Entities.CookBook
{
    public class UnitEntity: AEntity
    {
        public int UnitId => Id; 
        public string Name { get; set; } = string.Empty;
    }
}
