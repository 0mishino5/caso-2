using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories.Interfaces;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class HitoProyectoRepository : Repository<HitoProyecto>, IHitoProyectoRepository
{
    public HitoProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
