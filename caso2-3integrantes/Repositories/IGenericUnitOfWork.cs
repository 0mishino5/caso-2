namespace caso2_3integrantes.Repositories;

public interface IGenericUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveAsync();
}
