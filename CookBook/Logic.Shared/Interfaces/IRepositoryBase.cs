using Data.Models.Entities;
using Logic.Shared.Models;

namespace Logic.Shared.Interfaces
{
    public interface IRepositoryBase<T> where T : AEntity
    {
        Task<IQueryable<T>> GetAllAsync(DbQuery<T> dbQuery);
        Task<T?> GetFirstOrDefaultAsync(DbQuery<T> dbQuery);
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(T entity, bool force = false);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
