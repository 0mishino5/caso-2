using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class InformeProgresoRepository : Repository<Informesprogreso>, IInformeProgresoRepository
{
    public InformeProgresoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
