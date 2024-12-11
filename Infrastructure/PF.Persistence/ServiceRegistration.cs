using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PF.Domain.Entities.Identity;
using PF.Persistence.Contexts;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PFDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
        services.AddIdentity<User, Role>().AddEntityFrameworkStores<PFDbContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        return services;
    }
}