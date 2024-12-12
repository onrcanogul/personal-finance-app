using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PF.Application.Abstraction.Activity;
using PF.Application.Abstraction.Expense;
using PF.Application.Abstraction.Income;
using PF.Application.Abstraction.src;
using PF.Application.Activity;
using PF.Application.Expense;
using PF.Application.Income;
using PF.Application.src;
using PF.Application.src.Abstraction.Base;
using PF.Application.src.Base;
using PF.Application.src.Base.Mapping;

namespace PF.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(BaseMapping)));
        services.AddScoped(typeof(ICrudService<,>), typeof(CrudService<,>));
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IIncomeService, IncomeService>();
        services.AddScoped<IActivityService, ActivityService>();
        return services;
    }
}