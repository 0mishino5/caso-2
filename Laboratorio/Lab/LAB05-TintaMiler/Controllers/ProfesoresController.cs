using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfesoresController : ControllerBase
{
    private readonly IProfesorService _profesorService;

    public ProfesoresController(IProfesorService profesorService)
    {
        _profesorService = profesorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
    {
        return Ok(await _profesorService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Profesor>> GetProfesor(int id)
    {
        return Ok(await _profesorService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Profesor>> CreateProfesor(Profesor profesor)
    {
        var nuevoProfesor = await _profesorService.CreateAsync(profesor);
        return CreatedAtAction(nameof(GetProfesor), new { id = nuevoProfesor.IdProfesor }, nuevoProfesor);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProfesor(int id, Profesor profesor)
    {
        await _profesorService.UpdateAsync(id, profesor);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProfesor(int id)
    {
        await _profesorService.DeleteAsync(id);
        return NoContent();
    }
}
