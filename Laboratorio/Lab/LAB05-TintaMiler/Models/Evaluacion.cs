namespace LAB05_TintaMiler.Models;

public class Evaluacion
{
    public int IdEvaluacion { get; set; }
    public int IdEstudiante { get; set; }
    public int IdCurso { get; set; }
    public decimal? Calificacion { get; set; }
    public DateOnly? Fecha { get; set; }

    public Estudiante? Estudiante { get; set; }
    public Curso? Curso { get; set; }
}
