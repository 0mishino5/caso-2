using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class TareaProyectoRepository : Repository<Tareasproyecto>, ITareaProyectoRepository
{
    public TareaProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
