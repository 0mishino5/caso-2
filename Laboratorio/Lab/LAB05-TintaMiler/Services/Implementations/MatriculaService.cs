using LAB05_TintaMiler.Dtos;
using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LAB05_TintaMiler.Services.Implementations;

public class MatriculaService : IMatriculaService
{
    private readonly IUnitOfWork _unitOfWork;

    public MatriculaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Matricula>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Matricula>().GetAllAsync(
            m => m.Estudiante!,
            m => m.Curso!);
    }

    public async Task<Matricula> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Matricula>().FirstOrDefaultAsync(
            m => m.IdMatricula == id,
            m => m.Estudiante!,
            m => m.Curso!) ?? throw new KeyNotFoundException("La matricula no existe.");
    }

    public async Task<Matricula> CreateAsync(Matricula matricula)
    {
        await ValidarDatosMatriculaAsync(matricula.IdEstudiante, matricula.IdCurso);
        matricula.IdMatricula = 0;
        matricula.Estudiante = null;
        matricula.Curso = null;

        await _unitOfWork.Repository<Matricula>().AddAsync(matricula);
        await _unitOfWork.SaveAsync();
        return matricula;
    }

    public async Task<Matricula> MatricularEstudianteAsync(MatricularEstudianteRequest request)
    {
        return await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            await ValidarDatosMatriculaAsync(request.IdEstudiante, request.IdCurso);

            var yaExiste = await _unitOfWork.Repository<Matricula>().ExistsAsync(m =>
                m.IdEstudiante == request.IdEstudiante
                && m.IdCurso == request.IdCurso
                && m.Semestre == request.Semestre);

            if (yaExiste)
            {
                throw new InvalidOperationException("El estudiante ya esta matriculado en ese curso y semestre.");
            }

            var matricula = new Matricula
            {
                IdEstudiante = request.IdEstudiante,
                IdCurso = request.IdCurso,
                Semestre = request.Semestre
            };

            await _unitOfWork.Repository<Matricula>().AddAsync(matricula);
            await _unitOfWork.SaveAsync();
            return matricula;
        });
    }

    public async Task<CursoMatriculaDetalleDto> GetDetalleCursoAsync(int idCurso)
    {
        var curso = await _unitOfWork.Repository<Curso>().FirstOrDefaultAsync(
            c => c.IdCurso == idCurso,
            c => c.Materias) ?? throw new KeyNotFoundException("El curso no existe.");

        var matriculas = await _unitOfWork.Repository<Matricula>().Query()
            .AsNoTracking()
            .Where(m => m.IdCurso == idCurso)
            .Include(m => m.Estudiante)
            .Include(m => m.Curso)
            .ToListAsync();

        var evaluaciones = await _unitOfWork.Repository<Evaluacion>().WhereAsync(e => e.IdCurso == idCurso);
        var asistencias = await _unitOfWork.Repository<Asistencia>().WhereAsync(a => a.IdCurso == idCurso);
        var docentesDisponibles = await _unitOfWork.Repository<Profesor>().GetAllAsync();

        return new CursoMatriculaDetalleDto
        {
            Curso = curso,
            Matriculas = matriculas,
            Estudiantes = matriculas
                .Where(m => m.Estudiante is not null)
                .Select(m => m.Estudiante!)
                .DistinctBy(e => e.IdEstudiante)
                .ToList(),
            Materias = curso.Materias,
            Evaluaciones = evaluaciones,
            Asistencias = asistencias,
            DocentesDisponibles = docentesDisponibles
        };
    }

    public async Task<IEnumerable<Matricula>> GetByEstudianteAsync(int idEstudiante)
    {
        var existeEstudiante = await _unitOfWork.Repository<Estudiante>().ExistsAsync(e => e.IdEstudiante == idEstudiante);

        if (!existeEstudiante)
        {
            throw new KeyNotFoundException("El estudiante no existe.");
        }

        return await _unitOfWork.Repository<Matricula>().WhereAsync(
            m => m.IdEstudiante == idEstudiante,
            m => m.Estudiante!,
            m => m.Curso!);
    }

    public async Task UpdateAsync(int id, Matricula matricula)
    {
        var matriculaExistente = await GetByIdAsync(id);
        await ValidarDatosMatriculaAsync(matricula.IdEstudiante, matricula.IdCurso);

        matriculaExistente.IdEstudiante = matricula.IdEstudiante;
        matriculaExistente.IdCurso = matricula.IdCurso;
        matriculaExistente.Semestre = matricula.Semestre;
        matriculaExistente.Estudiante = null;
        matriculaExistente.Curso = null;

        _unitOfWork.Repository<Matricula>().Update(matriculaExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var matricula = await GetByIdAsync(id);
        _unitOfWork.Repository<Matricula>().Delete(matricula);
        await _unitOfWork.SaveAsync();
    }

    private async Task ValidarDatosMatriculaAsync(int idEstudiante, int idCurso)
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
