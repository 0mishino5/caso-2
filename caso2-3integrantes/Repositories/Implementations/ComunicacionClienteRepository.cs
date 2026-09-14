using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class ComunicacionClienteRepository : Repository<Comunicacionescliente>, IComunicacionClienteRepository
{
    public ComunicacionClienteRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
