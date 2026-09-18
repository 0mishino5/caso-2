using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface IAsistenciaService
{
    Task<IEnumerable<Asistencia>> GetAllAsync();
    Task<Asistencia> GetByIdAsync(int id);
    Task<Asistencia> CreateAsync(Asistencia asistencia);
    Task UpdateAsync(int id, Asistencia asistencia);
    Task DeleteAsync(int id);
}
