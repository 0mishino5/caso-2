using System.Linq.Expressions;
using LAB05_TintaMiler.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB05_TintaMiler.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly LaboratorioDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(LaboratorioDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        return await ApplyIncludes(_dbSet.AsNoTracking(), includes).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includes)
    {
        return await ApplyIncludes(_dbSet.AsNoTracking(), includes).FirstOrDefaultAsync(filter);
    }

    public async Task<IEnumerable<T>> WhereAsync(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includes)
    {
        return await ApplyIncludes(_dbSet.AsNoTracking(), includes).Where(filter).ToListAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.AnyAsync(filter);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddAndSaveAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    private static IQueryable<T> ApplyIncludes(
        IQueryable<T> query,
        IEnumerable<Expression<Func<T, object>>> includes)
    {
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}
