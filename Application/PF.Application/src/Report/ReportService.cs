using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Report;
using PF.Application.Abstraction.Report.Dto;
using PF.Application.src.Base;
using PF.Common.Models.Enums;
using PF.Common.Models.Response;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Report;

public class ReportService(IRepository<Domain.Entities.Report> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer) 
    : CrudService<Domain.Entities.Report, ReportDto>(repository, mapper, unitOfWork, localizer), IReportService
{
    public async Task<Response<ReportDto>> Get(Guid userId, ReportType reportType)
    {
        var report = await repository.GetFirstOrDefaultAsync(
            predicate: x => x.UserId == userId.ToString(),
            includeProperties: i => i.Include(x => x.User!.Expenses)
                .Include(x => x.User!.Incomes.Where(SetPredicate(reportType))));
        
        var dto = mapper.Map<ReportDto>(report);
        return Response<ReportDto>.Success(dto, StatusCodes.Status200OK);
    }

    private static Func<Domain.Entities.Income, bool> SetPredicate(ReportType reportType)
    {
        return reportType switch
        {
            ReportType.Daily => income => income.CreatedDate > DateTime.Now.AddDays(-1),
            ReportType.Weekly => income => income.CreatedDate >= DateTime.Now.AddDays(-7),
            ReportType.Monthly => income => income.CreatedDate >= DateTime.Now.AddMonths(-1),
            ReportType.Yearly => income => income.CreatedDate >= DateTime.Now.AddYears(-365),
            ReportType.AllTime => income => true,
            _ => income => income.CreatedDate >= DateTime.Now.AddMonths(-365),
        };
    }
}