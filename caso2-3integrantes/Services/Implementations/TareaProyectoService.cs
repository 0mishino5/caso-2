using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class TareaProyectoService : CrudService<Tareasproyecto>, ITareaProyectoService
{
    public TareaProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.TareasProyecto, unitOfWork, "La tarea")
    {
    }
}
