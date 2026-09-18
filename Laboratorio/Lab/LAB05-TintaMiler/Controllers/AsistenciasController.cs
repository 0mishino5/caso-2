using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AsistenciasController : ControllerBase
{
    private readonly IAsistenciaService _asistenciaService;

    public AsistenciasController(IAsistenciaService asistenciaService)
    {
        _asistenciaService = asistenciaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asistencia>>> GetAsistencias()
    {
        return Ok(await _asistenciaService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Asistencia>> GetAsistencia(int id)
    {
        return Ok(await _asistenciaService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Asistencia>> CreateAsistencia(Asistencia asistencia)
    {
        var nuevaAsistencia = await _asistenciaService.CreateAsync(asistencia);
        return CreatedAtAction(nameof(GetAsistencia), new { id = nuevaAsistencia.IdAsistencia }, nuevaAsistencia);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsistencia(int id, Asistencia asistencia)
    {
        await _asistenciaService.UpdateAsync(id, asistencia);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsistencia(int id)
    {
        await _asistenciaService.DeleteAsync(id);
        return NoContent();
    }
}
