using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;

namespace LAB05_TintaMiler.Services.Implementations;

public class AsistenciaService : IAsistenciaService
{
    private static readonly HashSet<string> EstadosPermitidos = new(StringComparer.OrdinalIgnoreCase)
    {
        "Presente",
        "Ausente",
        "Justificada"
    };

    private readonly IUnitOfWork _unitOfWork;

    public AsistenciaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Asistencia>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Asistencia>().GetAllAsync(
            a => a.Estudiante!,
            a => a.Curso!);
    }

    public async Task<Asistencia> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Asistencia>().FirstOrDefaultAsync(
            a => a.IdAsistencia == id,
            a => a.Estudiante!,
            a => a.Curso!) ?? throw new KeyNotFoundException("La asistencia no existe.");
    }

    public async Task<Asistencia> CreateAsync(Asistencia asistencia)
    {
        await ValidarRelacionesAsync(asistencia.IdEstudiante, asistencia.IdCurso);
        ValidarEstado(asistencia.Estado);

        asistencia.IdAsistencia = 0;
        asistencia.Estudiante = null;
        asistencia.Curso = null;

        await _unitOfWork.Repository<Asistencia>().AddAsync(asistencia);
        await _unitOfWork.SaveAsync();
        return asistencia;
    }

    public async Task UpdateAsync(int id, Asistencia asistencia)
    {
        var asistenciaExistente = await GetByIdAsync(id);
        await ValidarRelacionesAsync(asistencia.IdEstudiante, asistencia.IdCurso);
        ValidarEstado(asistencia.Estado);

        asistenciaExistente.IdEstudiante = asistencia.IdEstudiante;
        asistenciaExistente.IdCurso = asistencia.IdCurso;
        asistenciaExistente.Fecha = asistencia.Fecha;
        asistenciaExistente.Estado = asistencia.Estado;
        asistenciaExistente.Estudiante = null;
        asistenciaExistente.Curso = null;

        _unitOfWork.Repository<Asistencia>().Update(asistenciaExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var asistencia = await GetByIdAsync(id);
        _unitOfWork.Repository<Asistencia>().Delete(asistencia);
        await _unitOfWork.SaveAsync();
    }

    private async Task ValidarRelacionesAsync(int idEstudiante, int idCurso)
    {
        var existeEstudiante = await _unitOfWork.Repository<Estudiante>().ExistsAsync(e => e.IdEstudiante == idEstudiante);
        var existeCurso = await _unitOfWork.Repository<Curso>().ExistsAsync(c => c.IdCurso == idCurso);

        if (!existeEstudiante)
        {
            throw new KeyNotFoundException("El estudiante no existe.");
        }

        if (!existeCurso)
        {
            throw new KeyNotFoundException("El curso no existe.");
        }
    }

    private static void ValidarEstado(string? estado)
    {
        if (estado is null || !EstadosPermitidos.Contains(estado))
        {
            throw new InvalidOperationException("El estado debe ser Presente, Ausente o Justificada.");
        }
    }
}
