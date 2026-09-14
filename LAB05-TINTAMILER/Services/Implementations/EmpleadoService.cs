using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Repositories;
using LAB05_TINTAMILER.Services;

namespace LAB05_TINTAMILER.Services.Implementations;

public class EmpleadoService : CrudService<Empleado>, IEmpleadoService
{
    public EmpleadoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.Empleados, unitOfWork, "El empleado")
    {
    }
}
