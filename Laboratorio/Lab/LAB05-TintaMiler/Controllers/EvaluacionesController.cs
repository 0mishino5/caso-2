using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EvaluacionesController : ControllerBase
{
    private readonly IEvaluacionService _evaluacionService;

    public EvaluacionesController(IEvaluacionService evaluacionService)
    {
        _evaluacionService = evaluacionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evaluacion>>> GetEvaluaciones()
    {
        return Ok(await _evaluacionService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Evaluacion>> GetEvaluacion(int id)
    {
        return Ok(await _evaluacionService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Evaluacion>> CreateEvaluacion(Evaluacion evaluacion)
    {
        var nuevaEvaluacion = await _evaluacionService.CreateAsync(evaluacion);
        return CreatedAtAction(nameof(GetEvaluacion), new { id = nuevaEvaluacion.IdEvaluacion }, nuevaEvaluacion);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEvaluacion(int id, Evaluacion evaluacion)
    {
        await _evaluacionService.UpdateAsync(id, evaluacion);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEvaluacion(int id)
    {
        await _evaluacionService.DeleteAsync(id);
        return NoContent();
    }
}
