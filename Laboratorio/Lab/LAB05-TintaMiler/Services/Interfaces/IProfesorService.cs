using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface IProfesorService
{
    Task<IEnumerable<Profesor>> GetAllAsync();
    Task<Profesor> GetByIdAsync(int id);
    Task<Profesor> CreateAsync(Profesor profesor);
    Task UpdateAsync(int id, Profesor profesor);
    Task DeleteAsync(int id);
}
