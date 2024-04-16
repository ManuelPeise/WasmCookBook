using Data.AppContext;
using Data.Models.Entities;
using Logic.Shared.Interfaces;
using Logic.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Logic.Shared
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : AEntity
    {
        private readonly DbSet<T> _table;
        private readonly AppDbContext _appContext;
        private bool disposedValue;

        public RepositoryBase(AppDbContext appContext)
        {
            _appContext = appContext;
            _table = appContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(DbQuery<T> dbQuery)
        {
            IEnumerable<T> result = null;

            if (dbQuery.AsNoTracking)
            {
                result = _table.AsNoTracking();
            }
            else
            {
                result = _table.ToList();
            }

            if (dbQuery.WhereExpression != null)
            {
                result = result.ToList().Where(dbQuery.WhereExpression);
            }

            return await Task.FromResult(result);
        }
        
        public async Task<T?> GetFirstOrDefaultAsync(DbQuery<T> dbQuery)
        {
            IEnumerable<T> query = null;

            if (!dbQuery.AsNoTracking)
            {
                 query = _table.ToList();
            }
            else
            {
                query = _table.AsNoTracking();
            }

            if (dbQuery.WhereExpression != null)
            {
                return  query.FirstOrDefault(dbQuery.WhereExpression);
            }

            return null;
        }

        public async Task<bool> AddAsync(T entity)
        {
            var existing = await _table.FindAsync(entity);

            if (existing == null)
            {
                _table.Add(entity);

                return true;
            }

            return false;
        }
        
        public async Task<bool> AddAsync(T entity, bool force = false)
        {
            var existing = default(T);

            if (!force)
            {
                existing = await _table.FindAsync(entity);

                if (existing == null)
                {
                    _table.Add(entity);

                    return true;
                }

                return false;
            }

            _table.Add(entity);

            return true;
        }
        
        public async Task<(int, bool)> AddIfNotExists(T entity, Func<T, bool> predicate, bool shouldSave)
        {
            var existing = _table.AsNoTracking().FirstOrDefault(predicate);

            if (existing == null)
            {
                var result = await _table.AddAsync(entity);

                if (shouldSave)
                {
                    var saveResult = await _appContext.SaveChangesAsync();

                    return (result.Entity.Id, true);
                }

            }

            return (existing.Id, false);
        }
        
        public async Task<bool> UpdateAsync(T entity, Func<T, bool> predicate)
        {
            var existing = _table.AsNoTracking().FirstOrDefault(predicate);

            if (existing != null)
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

            if (existing != null)
            {
                _table.Remove(existing);

                return true;
            }

            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // _appContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
