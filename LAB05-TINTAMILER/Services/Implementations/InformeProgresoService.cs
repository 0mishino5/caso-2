using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class InformeProgresoService : CrudService<InformeProgreso>, IInformeProgresoService
{
    public InformeProgresoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.InformesProgreso, unitOfWork, "El informe")
    {
    }
}
