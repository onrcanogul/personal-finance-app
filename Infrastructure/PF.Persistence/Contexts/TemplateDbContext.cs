using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PF.Common.Models.Entities;
using PF.Domain.Entities;
using PF.Domain.Entities.Identity;

namespace PF.Persistence.Contexts;

public class PFDbContext(DbContextOptions<PFDbContext> options, IHttpContextAccessor httpContextAccessor) : IdentityDbContext<User,Role,Guid>(options)
{
    public DbSet<Product> Products { get; set; }
    
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
                    baseEntity.UpdatedBy = GetCurrentUsername();
                    break;
                case EntityState.Added:
                    baseEntity.CreatedDate = DateTime.UtcNow;
                    baseEntity.UpdatedDate = DateTime.UtcNow;
                    baseEntity.CreatedBy = GetCurrentUsername();
                    break;
            }
        }
    }
    private string? GetCurrentUsername()
        => httpContextAccessor.HttpContext?.User.Identity!.Name;
}