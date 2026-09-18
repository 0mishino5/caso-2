using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface ICursoService
{
    Task<IEnumerable<Curso>> GetAllAsync();
    Task<Curso> GetByIdAsync(int id);
    Task<Curso> CreateAsync(Curso curso);
    Task UpdateAsync(int id, Curso curso);
    Task DeleteAsync(int id);
}
