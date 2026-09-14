using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class PresupuestoProyectoService : CrudService<Presupuestosproyecto>, IPresupuestoProyectoService
{
    public PresupuestoProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.PresupuestosProyecto, unitOfWork, "El presupuesto")
    {
    }
}
