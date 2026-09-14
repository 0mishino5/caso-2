using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(ConsultoriaDbContext context) : base(context)
    {
    }
}
