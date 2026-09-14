using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services.Interfaces;

namespace LAB05_TINTAMILER.Services.Implementations;

public class ClienteService : CrudService<Cliente>, IClienteService
{
    public ClienteService(IUnitOfWork unitOfWork)
        : base(unitOfWork.Clientes, unitOfWork, "El cliente")
    {
    }
}
