namespace PF.Persistence.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}