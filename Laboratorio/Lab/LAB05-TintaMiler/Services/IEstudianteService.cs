using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface IEstudianteService
{
    Task<IEnumerable<Estudiante>> GetAllAsync();
    Task<Estudiante> GetByIdAsync(int id);
    Task<Estudiante> CreateAsync(Estudiante estudiante);
    Task UpdateAsync(int id, Estudiante estudiante);
    Task DeleteAsync(int id);
}
