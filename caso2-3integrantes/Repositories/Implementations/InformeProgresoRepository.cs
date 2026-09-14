using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class InformeProgresoRepository : Repository<Informesprogreso>, IInformeProgresoRepository
{
    public InformeProgresoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
