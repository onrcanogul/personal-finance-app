using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Budget;
using PF.Application.Abstraction.Budget.Dto;
using PF.Application.src.Base;
using PF.Common.Models.Response;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Budget;

public class BudgetService(IRepository<Domain.Entities.Budget> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer)
    : CrudService<Domain.Entities.Budget, BudgetDto>(repository, mapper, unitOfWork, localizer), IBudgetService
{
    public async Task<Response<BudgetDto>> GetWithUser(Guid userId)
    {
        var entity = await repository.GetFirstOrDefaultAsync(x => x.UserId == userId.ToString(),
            includeProperties: 
            i => i.Include(x => x.User).ThenInclude(x => x.Expenses)
                .Include(x => x.User).ThenInclude(x => x.Expenses));
        var dto = mapper.Map<BudgetDto>(entity);
        return Response<BudgetDto>.Success(dto, StatusCodes.Status200OK);
    }   
}