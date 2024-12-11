using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PF.Common.Models.Entities;

namespace PF.Persistence.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T?> GetQueryable();
    Task<List<T?>> GetListAsync(Expression<Func<T?, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T?, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<List<T?>> GetPagedListAsync(int page, int size,Expression<Func<T, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task CreateAsync(T? entity);
    void Update(T? entity);
    void Delete(T? entity);
}