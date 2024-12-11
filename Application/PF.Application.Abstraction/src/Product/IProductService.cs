using PF.Application.src.Abstraction.Base;
using PF.Application.src.Abstraction.Dto;
using PF.Domain.Entities;

namespace PF.Application.src.Abstraction;

public interface IProductService : ICrudService<Product, ProductDto>
{
}