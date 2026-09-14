using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TINTAMILER.Controllers;

[Route("api/[controller]")]
public class InformesProgresoController : CrudController<Informesprogreso>
{
    public InformesProgresoController(IInformeProgresoService informeProgresoService) : base(informeProgresoService)
    {
    }
}
