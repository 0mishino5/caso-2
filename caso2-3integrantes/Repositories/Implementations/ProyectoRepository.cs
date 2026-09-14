using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
{
    public ProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
