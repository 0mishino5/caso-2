using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories.Interfaces;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class PresupuestoProyectoRepository : Repository<Presupuestosproyecto>, IPresupuestoProyectoRepository
{
    public PresupuestoProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
