using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class HitoProyectoService : CrudService<HitoProyecto>, IHitoProyectoService
{
    public HitoProyectoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.HitosProyecto, unitOfWork, "El hito")
    {
    }
}
