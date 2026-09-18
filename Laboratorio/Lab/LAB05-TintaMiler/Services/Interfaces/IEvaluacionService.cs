using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface IEvaluacionService
{
    Task<IEnumerable<Evaluacion>> GetAllAsync();
    Task<Evaluacion> GetByIdAsync(int id);
    Task<Evaluacion> CreateAsync(Evaluacion evaluacion);
    Task UpdateAsync(int id, Evaluacion evaluacion);
    Task DeleteAsync(int id);
}
