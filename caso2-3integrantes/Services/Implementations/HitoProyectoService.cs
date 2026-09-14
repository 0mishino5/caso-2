using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class HitoProyectoService : CrudService<Hitosproyecto>, IHitoProyectoService
{
    public HitoProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.HitosProyecto, unitOfWork, "El hito")
    {
    }
}
