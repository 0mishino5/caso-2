using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursosController : ControllerBase
{
    private readonly ICursoService _cursoService;

    public CursosController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
    {
        return Ok(await _cursoService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Curso>> GetCurso(int id)
    {
        return Ok(await _cursoService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Curso>> CreateCurso(Curso curso)
    {
        var nuevoCurso = await _cursoService.CreateAsync(curso);
        return CreatedAtAction(nameof(GetCurso), new { id = nuevoCurso.IdCurso }, nuevoCurso);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCurso(int id, Curso curso)
    {
        await _cursoService.UpdateAsync(id, curso);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCurso(int id)
    {
        await _cursoService.DeleteAsync(id);
        return NoContent();
    }
}
