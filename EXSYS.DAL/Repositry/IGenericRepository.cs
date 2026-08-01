using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Repositry
{
        public interface IGenericRepository<T> where T : class
        {
            Task<List<T>> GetAllAsync(Expression<Func<T, bool>> fillter = null, string[]? include = null);
            IQueryable<T> GetQueryable(Expression<Func<T, bool>> fillter = null, string[]? include = null);
            Task<T> CreateAsync(T entity);
            Task<T?> GetOne(Expression<Func<T, bool>> filter, string[]? include = null);

            Task<bool> DeleteAsync(T entity);
            Task<bool> UpdateAsync(T entity);
            Task<bool> DeleteRangeAsync(List<T> entities);

            Task<bool> UpdateRangeAsync(List<T> entities);
        }
    }

