using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
