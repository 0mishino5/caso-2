using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MateriasController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriasController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Materia>>> GetMaterias()
    {
        return Ok(await _materiaService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Materia>> GetMateria(int id)
    {
        return Ok(await _materiaService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Materia>> CreateMateria(Materia materia)
    {
        var nuevaMateria = await _materiaService.CreateAsync(materia);
        return CreatedAtAction(nameof(GetMateria), new { id = nuevaMateria.IdMateria }, nuevaMateria);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMateria(int id, Materia materia)
    {
        await _materiaService.UpdateAsync(id, materia);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMateria(int id)
    {
        await _materiaService.DeleteAsync(id);
        return NoContent();
    }
}
