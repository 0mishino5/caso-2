namespace LAB05_TINTAMILER.Repositories;

public interface IGenericUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveAsync();
}
