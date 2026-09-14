using caso2_3integrantes.Models;
using caso2_3integrantes.Services;
using Microsoft.AspNetCore.Mvc;

namespace caso2_3integrantes.Controllers;

[Route("api/[controller]")]
public class EmpleadosController : CrudController<Empleado>
{
    public EmpleadosController(IEmpleadoService empleadoService) : base(empleadoService)
    {
    }
}
