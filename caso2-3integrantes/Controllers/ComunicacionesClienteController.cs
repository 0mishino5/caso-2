using caso2_3integrantes.Models;
using caso2_3integrantes.Services;
using Microsoft.AspNetCore.Mvc;

namespace caso2_3integrantes.Controllers;

[Route("api/[controller]")]
public class ComunicacionesClienteController : CrudController<Comunicacionescliente>
{
    public ComunicacionesClienteController(IComunicacionClienteService comunicacionClienteService) : base(comunicacionClienteService)
    {
    }
}
