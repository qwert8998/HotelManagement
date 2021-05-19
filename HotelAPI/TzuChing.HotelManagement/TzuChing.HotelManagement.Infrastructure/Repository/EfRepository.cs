using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.Infrastructure.Data;

namespace TzuChing.HotelManagement.Infrastructure.Repository
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly HotelManagementDBContext _dbContext;

        public EfRepository(HotelManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _dbContext.Set<T>().Where(filter).CountAsync();
        }

        public virtual async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return false;
            }

            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
