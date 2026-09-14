using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TINTAMILER.Controllers;

[Route("api/[controller]")]
public class TareasProyectoController : CrudController<Tareasproyecto>
{
    public TareasProyectoController(ITareaProyectoService tareaProyectoService) : base(tareaProyectoService)
    {
    }
}
