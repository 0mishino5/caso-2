using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class ClienteService : CrudService<Cliente>, IClienteService
{
    public ClienteService(IUnitOfWork unitOfWork)
        : base(unitOfWork.Clientes, unitOfWork, "El cliente")
    {
    }
}
