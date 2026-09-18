using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;

namespace LAB05_TintaMiler.Services.Implementations;

public class EvaluacionService : IEvaluacionService
{
    private readonly IUnitOfWork _unitOfWork;

    public EvaluacionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Evaluacion>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Evaluacion>().GetAllAsync(
            e => e.Estudiante!,
            e => e.Curso!);
    }

    public async Task<Evaluacion> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Evaluacion>().FirstOrDefaultAsync(
            e => e.IdEvaluacion == id,
            e => e.Estudiante!,
            e => e.Curso!) ?? throw new KeyNotFoundException("La evaluacion no existe.");
    }

    public async Task<Evaluacion> CreateAsync(Evaluacion evaluacion)
    {
        await ValidarRelacionesAsync(evaluacion.IdEstudiante, evaluacion.IdCurso);
        evaluacion.IdEvaluacion = 0;
        evaluacion.Estudiante = null;
        evaluacion.Curso = null;

        await _unitOfWork.Repository<Evaluacion>().AddAsync(evaluacion);
        await _unitOfWork.SaveAsync();
        return evaluacion;
    }

    public async Task UpdateAsync(int id, Evaluacion evaluacion)
    {
        var evaluacionExistente = await GetByIdAsync(id);
        await ValidarRelacionesAsync(evaluacion.IdEstudiante, evaluacion.IdCurso);

        evaluacionExistente.IdEstudiante = evaluacion.IdEstudiante;
        evaluacionExistente.IdCurso = evaluacion.IdCurso;
        evaluacionExistente.Calificacion = evaluacion.Calificacion;
        evaluacionExistente.Fecha = evaluacion.Fecha;
        evaluacionExistente.Estudiante = null;
        evaluacionExistente.Curso = null;

        _unitOfWork.Repository<Evaluacion>().Update(evaluacionExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var evaluacion = await GetByIdAsync(id);
        _unitOfWork.Repository<Evaluacion>().Delete(evaluacion);
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
}
