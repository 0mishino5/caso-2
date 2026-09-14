using caso2_3integrantes.Models;
using caso2_3integrantes.Services;
using Microsoft.AspNetCore.Mvc;

namespace caso2_3integrantes.Controllers;

[Route("api/[controller]")]
public class HitosProyectoController : CrudController<Hitosproyecto>
{
    public HitosProyectoController(IHitoProyectoService hitoProyectoService) : base(hitoProyectoService)
    {
    }
}
