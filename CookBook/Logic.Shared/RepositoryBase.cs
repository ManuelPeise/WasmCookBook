using Data.AppContext;
using Data.Models.Entities;
using Logic.Shared.Interfaces;
using Logic.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Logic.Shared
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : AEntity
    {
        private readonly DbSet<T> _table;
        public RepositoryBase(AppDbContext appContext)
        {
            _table = appContext.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync(DbQuery<T> dbQuery)
        {
            var query = _table.AsQueryable();

            if(dbQuery.AsNoTracking) 
            { 
                query = query.AsNoTracking();
            }

            if(dbQuery.WhereExpression != null)
            {
                query = query.Where(dbQuery.WhereExpression);
            }

            return await Task.FromResult(query);
        }
        public async Task<T?> GetFirstOrDefaultAsync(DbQuery<T> dbQuery)
        {
            var query = _table.AsQueryable();

            if (dbQuery.AsNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (dbQuery.WhereExpression != null)
            {
                return await query.FirstOrDefaultAsync(dbQuery.WhereExpression);
            }

            return null;
        }
        public async Task<bool> AddAsync(T entity)
        {
            var existing = await _table.FindAsync(entity);

            if(existing == null) 
            { 
                _table.Add(entity);
          
                return true;
            }

            return false;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            var existing = await _table.FindAsync(entity);

            if(existing != null)
            {
                existing = entity;

                _table.Update(existing);

                return true;
            }

            return false;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _table.FindAsync(id);

            if(existing != null)
            {
                _table.Remove(existing);

                return true;
            }

            return false;
        }
    }
}
