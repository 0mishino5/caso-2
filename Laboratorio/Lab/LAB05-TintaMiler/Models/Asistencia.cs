namespace LAB05_TintaMiler.Models;

public class Asistencia
{
    public int IdAsistencia { get; set; }
    public int IdEstudiante { get; set; }
    public int IdCurso { get; set; }
    public DateOnly? Fecha { get; set; }
    public string? Estado { get; set; }

    public Estudiante? Estudiante { get; set; }
    public Curso? Curso { get; set; }
}
