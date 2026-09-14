using LAB05_TINTAMILER.Models;
using LAB05_TINTAMILER.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TINTAMILER.Controllers;

[Route("api/[controller]")]
public class ComunicacionesClienteController : CrudController<Comunicacionescliente>
{
    public ComunicacionesClienteController(IComunicacionClienteService comunicacionClienteService) : base(comunicacionClienteService)
    {
    }
}
