using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class HitoProyectoRepository : Repository<Hitosproyecto>, IHitoProyectoRepository
{
    public HitoProyectoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
