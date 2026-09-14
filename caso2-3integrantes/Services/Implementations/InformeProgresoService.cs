using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class InformeProgresoService : CrudService<Informesprogreso>, IInformeProgresoService
{
    public InformeProgresoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.InformesProgreso, unitOfWork, "El informe")
    {
    }
}
