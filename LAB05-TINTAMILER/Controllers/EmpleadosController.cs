using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TINTAMILER.Controllers;

[Route("api/[controller]")]
public class EmpleadosController : CrudController<Empleado>
{
    public EmpleadosController(IEmpleadoService empleadoService) : base(empleadoService)
    {
    }
}
