using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;

namespace LAB05_TintaMiler.Services.Implementations;

public class CursoService : ICursoService
{
    private readonly IUnitOfWork _unitOfWork;

    public CursoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Curso>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Curso>().GetAllAsync();
    }

    public async Task<Curso> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Curso>().FirstOrDefaultAsync(
            c => c.IdCurso == id,
            c => c.Materias,
            c => c.Matriculas,
            c => c.Evaluaciones,
            c => c.Asistencias) ?? throw new KeyNotFoundException("El curso no existe.");
    }

    public async Task<Curso> CreateAsync(Curso curso)
    {
        curso.IdCurso = 0;
        await _unitOfWork.Repository<Curso>().AddAsync(curso);
        await _unitOfWork.SaveAsync();
        return curso;
    }

    public async Task UpdateAsync(int id, Curso curso)
    {
        var cursoExistente = await GetByIdAsync(id);

        cursoExistente.Nombre = curso.Nombre;
        cursoExistente.Descripcion = curso.Descripcion;
        cursoExistente.Creditos = curso.Creditos;

        _unitOfWork.Repository<Curso>().Update(cursoExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var curso = await GetByIdAsync(id);
        _unitOfWork.Repository<Curso>().Delete(curso);
        await _unitOfWork.SaveAsync();
    }
}
