using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;

namespace LAB05_TintaMiler.Services.Implementations;

public class MateriaService : IMateriaService
{
    private readonly IUnitOfWork _unitOfWork;

    public MateriaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Materia>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Materia>().GetAllAsync(m => m.Curso!);
    }

    public async Task<Materia> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Materia>().FirstOrDefaultAsync(
            m => m.IdMateria == id,
            m => m.Curso!) ?? throw new KeyNotFoundException("La materia no existe.");
    }

    public async Task<Materia> CreateAsync(Materia materia)
    {
        await ValidarCursoAsync(materia.IdCurso);
        materia.IdMateria = 0;
        materia.Curso = null;

        await _unitOfWork.Repository<Materia>().AddAsync(materia);
        await _unitOfWork.SaveAsync();
        return materia;
    }

    public async Task UpdateAsync(int id, Materia materia)
    {
        var materiaExistente = await GetByIdAsync(id);
        await ValidarCursoAsync(materia.IdCurso);

        materiaExistente.IdCurso = materia.IdCurso;
        materiaExistente.Nombre = materia.Nombre;
        materiaExistente.Descripcion = materia.Descripcion;
        materiaExistente.Curso = null;

        _unitOfWork.Repository<Materia>().Update(materiaExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var materia = await GetByIdAsync(id);
        _unitOfWork.Repository<Materia>().Delete(materia);
        await _unitOfWork.SaveAsync();
    }

    private async Task ValidarCursoAsync(int idCurso)
    {
        var existeCurso = await _unitOfWork.Repository<Curso>().ExistsAsync(c => c.IdCurso == idCurso);

        if (!existeCurso)
        {
            throw new KeyNotFoundException("El curso no existe.");
        }
    }
}
