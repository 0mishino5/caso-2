using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Repositories;
using LAB05_TintaMiler.Services.Interfaces;

namespace LAB05_TintaMiler.Services.Implementations;

public class EstudianteService : IEstudianteService
{
    private readonly IUnitOfWork _unitOfWork;

    public EstudianteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Estudiante>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Estudiante>().GetAllAsync();
    }

    public async Task<Estudiante> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Estudiante>().FirstOrDefaultAsync(
            e => e.IdEstudiante == id,
            e => e.Matriculas,
            e => e.Evaluaciones,
            e => e.Asistencias) ?? throw new KeyNotFoundException("El estudiante no existe.");
    }

    public async Task<Estudiante> CreateAsync(Estudiante estudiante)
    {
        estudiante.IdEstudiante = 0;
        await _unitOfWork.Repository<Estudiante>().AddAsync(estudiante);
        await _unitOfWork.SaveAsync();
        return estudiante;
    }

    public async Task UpdateAsync(int id, Estudiante estudiante)
    {
        var estudianteExistente = await GetByIdAsync(id);

        estudianteExistente.Nombre = estudiante.Nombre;
        estudianteExistente.Edad = estudiante.Edad;
        estudianteExistente.Direccion = estudiante.Direccion;
        estudianteExistente.Telefono = estudiante.Telefono;
        estudianteExistente.Correo = estudiante.Correo;

        _unitOfWork.Repository<Estudiante>().Update(estudianteExistente);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var estudiante = await GetByIdAsync(id);
        _unitOfWork.Repository<Estudiante>().Delete(estudiante);
        await _unitOfWork.SaveAsync();
    }
}
