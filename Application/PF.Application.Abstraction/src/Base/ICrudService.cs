using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PF.Common.Models.Dtos;
using PF.Common.Models.Entities;
using PF.Common.Models.Response;

namespace PF.Application.src.Abstraction.Base;

public interface ICrudService<T, TDto>
    where T : BaseEntity where TDto : BaseDto
{
    Task<Response<List<TDto>>> GetListAsync(Expression<Func<T?, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<Response<TDto>> GetFirstOrDefaultAsync(Expression<Func<T?, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<Response<List<TDto>>> GetPagedListAsync(int page, int size,Expression<Func<T, bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true);
    Task<Response<TDto>> CreateAsync(TDto dto);
    Task<Response<TDto>> UpdateAsync(TDto dto);
    Task<Response<NoContent>> DeleteAsync(Guid id);
}