using EXSYS.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Repositry
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            private readonly ApplicationDbContext dbContext;

            public GenericRepository(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<T> CreateAsync(T entity)
            {
                await dbContext.AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }

            public async Task<bool> DeleteAsync(T entity)
            {
                dbContext.Remove(entity);
                var affected = await dbContext.SaveChangesAsync();
                return affected > 0;
            }
            public async Task<bool> UpdateAsync(T entity)
            {
                dbContext.Update(entity);
                var affected = await dbContext.SaveChangesAsync();
                return affected > 0;

            }

            public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> fillter = null, string[]? include = null)
            {
                IQueryable<T> query = dbContext.Set<T>();
                if (fillter != null)
                {
                    query = query.Where(fillter);
                }

                if (include != null)
                {
                    foreach (var includeProperty in include)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.ToListAsync();
            }
            public IQueryable<T> GetQueryable(Expression<Func<T, bool>> fillter = null, string[]? include = null)
            {
                IQueryable<T> query = dbContext.Set<T>();
                if (fillter != null)
                {
                    query = query.Where(fillter);
                }

                if (include != null)
                {
                    foreach (var includeProperty in include)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return query;
            }

            public Task<T?> GetOne(Expression<Func<T, bool>> filter, string[]? include = null)
            {
                IQueryable<T> query = dbContext.Set<T>();

                if (include != null)
                {
                    foreach (var includeProperty in include)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return query.FirstOrDefaultAsync(filter);
            }

            public async Task<bool> DeleteRangeAsync(List<T> entities)
            {
                dbContext.RemoveRange(entities);
                return await dbContext.SaveChangesAsync() > 0;

            }

            public async Task<bool> UpdateRangeAsync(List<T> entities)
            {
                dbContext.UpdateRange(entities);
                return await dbContext.SaveChangesAsync() > 0;
            }
        }
    }

