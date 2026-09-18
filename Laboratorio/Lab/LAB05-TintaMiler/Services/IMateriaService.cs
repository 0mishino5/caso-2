using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface IMateriaService
{
    Task<IEnumerable<Materia>> GetAllAsync();
    Task<Materia> GetByIdAsync(int id);
    Task<Materia> CreateAsync(Materia materia);
    Task UpdateAsync(int id, Materia materia);
    Task DeleteAsync(int id);
}
