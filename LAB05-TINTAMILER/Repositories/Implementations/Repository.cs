using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ConsultoriaDbContext Context;

    public Repository(ConsultoriaDbContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        Context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
}
