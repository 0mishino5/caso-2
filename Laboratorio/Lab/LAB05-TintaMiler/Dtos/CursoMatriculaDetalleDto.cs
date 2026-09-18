using LAB05_TintaMiler.Models;

namespace LAB05_TintaMiler.Dtos;

public class CursoMatriculaDetalleDto
{
    public Curso Curso { get; set; } = null!;
    public IEnumerable<Matricula> Matriculas { get; set; } = new List<Matricula>();
    public IEnumerable<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    public IEnumerable<Materia> Materias { get; set; } = new List<Materia>();
    public IEnumerable<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    public IEnumerable<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    public IEnumerable<Profesor> DocentesDisponibles { get; set; } = new List<Profesor>();
}
