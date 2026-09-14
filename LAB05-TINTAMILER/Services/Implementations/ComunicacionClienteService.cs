using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class ComunicacionClienteService : CrudService<ComunicacionCliente>, IComunicacionClienteService
{
    public ComunicacionClienteService(IUnitOfWork unitOfWork)
        : base(unitOfWork.ComunicacionesCliente, unitOfWork, "La comunicacion")
    {
    }
}
