using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PF.Common.Models.Entities;
using PF.Domain.Entities;
using PF.Domain.Entities.Identity;

namespace PF.Persistence.Contexts;

public class PfDbContext(DbContextOptions<PfDbContext> options)
    : IdentityDbContext<User, Role, string>(options)
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseActivity> ExpenseActivities { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<IncomeActivity> IncomeActivities { get; set; }
    public DbSet<Report> Reports { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AuditingEntities();
        return base.SaveChangesAsync(cancellationToken);
    }
    public override int SaveChanges()
    {
        AuditingEntities();
        return base.SaveChanges();
    }
    
    private void AuditingEntities()
    {
        var dataList = ChangeTracker.Entries<BaseEntity>().ToList();

        foreach (var data in dataList)
        {
            var baseEntity = data.Entity;
            switch (data.State)
            {
                case EntityState.Modified:
                    baseEntity.UpdatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    baseEntity.CreatedDate = DateTime.UtcNow;
                    baseEntity.UpdatedDate = DateTime.UtcNow;
                    break;
            }
        }
    }
}