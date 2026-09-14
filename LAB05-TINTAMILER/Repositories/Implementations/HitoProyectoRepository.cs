using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class HitoProyectoRepository : Repository<Hitosproyecto>, IHitoProyectoRepository
{
    public HitoProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
