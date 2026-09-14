using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
