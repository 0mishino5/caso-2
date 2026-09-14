using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services;

namespace LAB05_TINTAMILER.Services.Implementations;

public class TareaProyectoService : CrudService<Tareasproyecto>, ITareaProyectoService
{
    public TareaProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.TareasProyecto, unitOfWork, "La tarea")
    {
    }
}
