using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class PresupuestoProyectoRepository : Repository<Presupuestosproyecto>, IPresupuestoProyectoRepository
{
    public PresupuestoProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
