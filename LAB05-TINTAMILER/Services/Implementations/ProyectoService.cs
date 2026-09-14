using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class ProyectoService : CrudService<Proyecto>, IProyectoService
{
    public ProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.Proyectos, unitOfWork, "El proyecto")
    {
    }
}
