using Data.Models.Entities.CookBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.AppContext.DataSeeds
{
    internal class IngredientUnitSeed : IEntityTypeConfiguration<UnitEntity>
    {
        public void Configure(EntityTypeBuilder<UnitEntity> builder)
        {
            builder.HasData(new List<UnitEntity>
           {
               new UnitEntity
               {
                   Id = 1,
                   Name = "Kg"
               },
               new UnitEntity
               {
                   Id = 2,
                   Name = "g"
               },
               new UnitEntity
               {
                   Id = 3,
                   Name = "Liter"
               },

           });
        }
    }
}
