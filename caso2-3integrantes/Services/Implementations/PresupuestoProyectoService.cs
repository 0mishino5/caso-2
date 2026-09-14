using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class PresupuestoProyectoService : CrudService<Presupuestosproyecto>, IPresupuestoProyectoService
{
    public PresupuestoProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.PresupuestosProyecto, unitOfWork, "El presupuesto")
    {
    }
}
