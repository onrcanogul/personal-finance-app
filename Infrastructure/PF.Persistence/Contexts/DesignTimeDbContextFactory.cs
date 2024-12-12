using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PF.Persistence.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PfDbContext>
{
    public PfDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PfDbContext>();
        optionsBuilder.UseNpgsql("User Id=postgres; Password=Password12*;Host=localhost;Port=5432;Database=PF-DB;");
        return new PfDbContext(optionsBuilder.Options);
    }
}