using Data.AppContext;
using Data.Models.Entities.Logging;
using Logic.Shared.Interfaces;
using Logic.Shared.Models;
using System.Linq.Expressions;

namespace Logic.Shared
{
    public abstract class ALogicBase
    {
        protected readonly AppDbContext _appDbContext;
        private readonly IRepositoryBase<LogMessageEntity> _logMessageRepo;

        protected ALogicBase(AppDbContext context)
        {
            _appDbContext = context;
            _logMessageRepo = new RepositoryBase<LogMessageEntity>(context);
        }

        protected async Task<List<LogMessageEntity>> GetLogMessages(Func<LogMessageEntity, bool>? expression = null)
        {
            var query = await _logMessageRepo.GetAllAsync(new DbQuery<LogMessageEntity>
            {
                AsNoTracking = true,
                WhereExpression = expression != null ? expression : null
            });

            return query.ToList();
        }

        protected async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }

        protected async Task LogError(LogMessageEntity entity)
        {
            await _logMessageRepo.AddAsync(entity);

            await SaveChanges();
        }
    }
}
