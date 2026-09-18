using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudiantesController : ControllerBase
{
    private readonly IEstudianteService _estudianteService;

    public EstudiantesController(IEstudianteService estudianteService)
    {
        _estudianteService = estudianteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
    {
        return Ok(await _estudianteService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
    {
        return Ok(await _estudianteService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Estudiante>> CreateEstudiante(Estudiante estudiante)
    {
        var nuevoEstudiante = await _estudianteService.CreateAsync(estudiante);
        return CreatedAtAction(nameof(GetEstudiante), new { id = nuevoEstudiante.IdEstudiante }, nuevoEstudiante);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEstudiante(int id, Estudiante estudiante)
    {
        await _estudianteService.UpdateAsync(id, estudiante);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEstudiante(int id)
    {
        await _estudianteService.DeleteAsync(id);
        return NoContent();
    }
}
