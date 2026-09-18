using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;

namespace LAB05_TintaMiler.Services.Implementations;

public class ProfesorService : IProfesorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProfesorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Profesor>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Profesor>().GetAllAsync();
    }

    public async Task<Profesor> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Profesor>().GetByIdAsync(id)
            ?? throw new KeyNotFoundException("El profesor no existe.");
    }

    public async Task<Profesor> CreateAsync(Profesor profesor)
    {
        profesor.IdProfesor = 0;
        await _unitOfWork.Repository<Profesor>().AddAsync(profesor);
        await _unitOfWork.SaveAsync();
        return profesor;
    }

    public async Task UpdateAsync(int id, Profesor profesor)
    {
        var profesorExistente = await GetByIdAsync(id);

        profesorExistente.Nombre = profesor.Nombre;
        profesorExistente.Especialidad = profesor.Especialidad;
        profesorExistente.Correo = profesor.Correo;

        _unitOfWork.Repository<Profesor>().Update(profesorExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var profesor = await GetByIdAsync(id);
        _unitOfWork.Repository<Profesor>().Delete(profesor);
        await _unitOfWork.SaveAsync();
    }
}
