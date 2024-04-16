using Data.Models.Entities;
using Logic.Shared.Models;

namespace Logic.Shared.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : AEntity
    {
        Task<IEnumerable<T>> GetAllAsync(DbQuery<T> dbQuery);
        Task<T?> GetFirstOrDefaultAsync(DbQuery<T> dbQuery);
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(T entity, bool force = false);
        Task<(int, bool)> AddIfNotExists(T entity, Func<T, bool> predicate, bool shouldSave);
        Task<bool> UpdateAsync(T entity, Func<T, bool> predicate);
        Task<bool> DeleteAsync(int id);
    }
}
