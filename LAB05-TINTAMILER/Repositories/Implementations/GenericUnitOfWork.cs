using LAB05_TINTAMILER.Models;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class GenericUnitOfWork : IGenericUnitOfWork
{
    private readonly ConsultoriaDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public GenericUnitOfWork(ConsultoriaDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        var entityType = typeof(T);

        if (!_repositories.ContainsKey(entityType))
        {
            _repositories[entityType] = new Repository<T>(_context);
        }

        return (IRepository<T>)_repositories[entityType];
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
