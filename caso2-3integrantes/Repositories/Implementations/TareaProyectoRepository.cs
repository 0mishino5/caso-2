using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class TareaProyectoRepository : Repository<Tareasproyecto>, ITareaProyectoRepository
{
    public TareaProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
