using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PF.Persistence.Contexts;

namespace PF.Persistence.UnitOfWork;

public class UnitOfWork(PFDbContext context) : IUnitOfWork
{
    public void Commit()
    {
        context.SaveChanges();
    }
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}