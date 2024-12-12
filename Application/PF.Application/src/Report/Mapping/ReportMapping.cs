using AutoMapper;
using PF.Application.Abstraction.Report.Dto;

namespace PF.Application.Report.Mapping;

public class ReportMapping : Profile
{
    public ReportMapping()
    {
        CreateMap<Domain.Entities.Report, ReportDto>().ReverseMap();
    }
}