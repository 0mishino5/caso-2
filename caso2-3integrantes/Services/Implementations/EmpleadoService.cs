using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Services;

namespace caso2_3integrantes.Services.Implementations;

public class EmpleadoService : CrudService<Empleado>, IEmpleadoService
{
    public EmpleadoService(IUnitOfWork unitOfWork)
        : base(unitOfWork.Empleados, unitOfWork, "El empleado")
    {
    }
}
