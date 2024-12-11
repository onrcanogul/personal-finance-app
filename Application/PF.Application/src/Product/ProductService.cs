using AutoMapper;
using Microsoft.Extensions.Localization;
using PF.Application.src.Abstraction;
using PF.Application.src.Abstraction.Dto;
using PF.Application.src.Base;
using PF.Domain.Entities;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.src;

public class ProductService
    (IRepository<Product> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer) 
    : CrudService<Product, ProductDto>(repository, mapper, unitOfWork, localizer),IProductService
{
    
}