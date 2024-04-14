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
                   Name = "Kilo"
               },
               new UnitEntity
               {
                   Id = 2,
                   Name = "Gramm"
               },
               new UnitEntity
               {
                   Id = 3,
                   Name = "Liter"
               },
               new UnitEntity
               {
                   Id = 4,
                   Name = "Milliliter"
               },
               new UnitEntity
               {
                   Id = 5,
                   Name = "Stück"
               },
               new UnitEntity
               {
                   Id = 6,
                   Name = "Messerspitze"
               },
               new UnitEntity
               {
                   Id = 7,
                   Name = "Esslöffen"
               },
               new UnitEntity
               {
                   Id = 8,
                   Name = "Teelöffel"
               },

           });
        }
    }
}
