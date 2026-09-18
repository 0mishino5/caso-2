using LAB05_TintaMiler.Dtos;
using LAB05_TintaMiler.Models;
using LAB05_TintaMiler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB05_TintaMiler.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatriculasController : ControllerBase
{
    private readonly IMatriculaService _matriculaService;

    public MatriculasController(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas()
    {
        return Ok(await _matriculaService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Matricula>> GetMatricula(int id)
    {
        return Ok(await _matriculaService.GetByIdAsync(id));
    }

    [HttpGet("estudiante/{idEstudiante:int}")]
    public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculasPorEstudiante(int idEstudiante)
    {
        return Ok(await _matriculaService.GetByEstudianteAsync(idEstudiante));
    }

    [HttpGet("curso/{idCurso:int}/detalle")]
    public async Task<ActionResult<CursoMatriculaDetalleDto>> GetDetalleCurso(int idCurso)
    {
        return Ok(await _matriculaService.GetDetalleCursoAsync(idCurso));
    }

    [HttpPost]
    public async Task<ActionResult<Matricula>> CreateMatricula(Matricula matricula)
    {
        var nuevaMatricula = await _matriculaService.CreateAsync(matricula);
        return CreatedAtAction(nameof(GetMatricula), new { id = nuevaMatricula.IdMatricula }, nuevaMatricula);
    }

    [HttpPost("matricular")]
    public async Task<ActionResult<Matricula>> MatricularEstudiante(MatricularEstudianteRequest request)
    {
        var nuevaMatricula = await _matriculaService.MatricularEstudianteAsync(request);
        return CreatedAtAction(nameof(GetMatricula), new { id = nuevaMatricula.IdMatricula }, nuevaMatricula);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMatricula(int id, Matricula matricula)
    {
        await _matriculaService.UpdateAsync(id, matricula);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMatricula(int id)
    {
        await _matriculaService.DeleteAsync(id);
        return NoContent();
    }
}
