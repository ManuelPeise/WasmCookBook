using Data.Models.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace Data.AppContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<LogMessageEntity> LogMessages { get; set; }
    }
}
