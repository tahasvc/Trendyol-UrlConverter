using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Entities;

namespace TrendyolCase.Core.Interfaces.Repositories
{
    public interface IRepository<T>  where T : class
    {
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
