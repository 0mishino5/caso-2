using System.Collections;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Repositories.Interfaces;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class CrudService<T> : ICrudService<T> where T : class
{
    private readonly IRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _entityName;

    public CrudService(IRepository<T> repository, IUnitOfWork unitOfWork, string entityName)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _entityName = entityName;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"{_entityName} no existe.");
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }

    public async Task UpdateAsync(int id, T entity)
    {
        var entityExists = await GetByIdAsync(id);
        CopyEditableValues(entity, entityExists);

        _repository.Update(entityExists);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        _repository.Delete(entity);
        await _unitOfWork.SaveAsync();
    }

    private static void CopyEditableValues(T source, T target)
    {
        var keyProperty = typeof(T).GetProperties()
            .FirstOrDefault(property => property.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase));

        foreach (var property in typeof(T).GetProperties())
        {
            if (!property.CanRead || !property.CanWrite || property.Name == keyProperty?.Name)
            {
                continue;
            }

            if (property.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                continue;
            }

            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                continue;
            }

            property.SetValue(target, property.GetValue(source));
        }
    }
}
