using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrendyolCase.Core.Data;
using TrendyolCase.Core.Entities;
using TrendyolCase.Core.Interfaces.Repositories;

namespace TrendyolCase.Core.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(long id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }
        public Task<T> GetByIdAsync(long id)
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }
        public Task<List<T>> ListAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }
        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
