using PF.Application.Abstraction.Report.Dto;
using PF.Application.src.Abstraction.Base;
using PF.Common.Models.Enums;
using PF.Common.Models.Response;

namespace PF.Application.Abstraction.Report;

public interface IReportService : ICrudService<Domain.Entities.Report, ReportDto>
{
    Task<Response<ReportDto>> Get(Guid userId, ReportType reportType);
}