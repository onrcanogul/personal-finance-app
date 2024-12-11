using Microsoft.Extensions.DependencyInjection;
using PF.Application.Abstraction.src;
using PF.Application.src;
using PF.Application.src.Abstraction;
using PF.Application.src.Abstraction.Base;
using PF.Application.src.Base;
using PF.Application.src.Mappings;

namespace PF.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductMapper).Assembly);
        services.AddScoped(typeof(ICrudService<,>), typeof(CrudService<,>));
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}