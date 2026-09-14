using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class ComunicacionClienteService : CrudService<Comunicacionescliente>, IComunicacionClienteService
{
    public ComunicacionClienteService(IUnitOfWork unitOfWork)
        : base(unitOfWork.ComunicacionesCliente, unitOfWork, "La comunicacion")
    {
    }
}
