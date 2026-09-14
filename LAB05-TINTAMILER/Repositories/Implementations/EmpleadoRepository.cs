using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;

namespace LAB05_TINTAMILER.Repositories.Implementations;

public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
