using LAB05_TintaMiler.Dtos;
using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Services.Interfaces;

public interface IMatriculaService
{
    Task<IEnumerable<Matricula>> GetAllAsync();
    Task<Matricula> GetByIdAsync(int id);
    Task<Matricula> CreateAsync(Matricula matricula);
    Task<Matricula> MatricularEstudianteAsync(MatricularEstudianteRequest request);
    Task<CursoMatriculaDetalleDto> GetDetalleCursoAsync(int idCurso);
    Task<IEnumerable<Matricula>> GetByEstudianteAsync(int idEstudiante);
    Task UpdateAsync(int id, Matricula matricula);
    Task DeleteAsync(int id);
}
