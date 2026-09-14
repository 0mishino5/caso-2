using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories.Interfaces;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class ComunicacionClienteRepository : Repository<Comunicacionescliente>, IComunicacionClienteRepository
{
    public ComunicacionClienteRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
