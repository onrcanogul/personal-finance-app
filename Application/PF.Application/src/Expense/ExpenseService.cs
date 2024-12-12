using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Expense;
using PF.Application.Abstraction.Expense.Dto;
using PF.Application.src.Base;
using PF.Domain.Entities.Identity;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Expense;

public class ExpenseService(IRepository<Domain.Entities.Expense> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer, UserManager<User> userManager) 
    : CrudService<Domain.Entities.Expense, ExpenseDto>(repository, mapper, unitOfWork, localizer), IExpenseService
{
}