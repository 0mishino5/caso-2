using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class ProyectoService : CrudService<Proyecto>, IProyectoService
{
    public ProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.Proyectos, unitOfWork, "El proyecto")
    {
    }
}
