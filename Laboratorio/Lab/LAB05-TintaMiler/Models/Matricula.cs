namespace LAB05_TintaMiler.Models;

public class Matricula
{
    public int IdMatricula { get; set; }
    public int IdEstudiante { get; set; }
    public int IdCurso { get; set; }
    public string? Semestre { get; set; }

    public Estudiante? Estudiante { get; set; }
    public Curso? Curso { get; set; }
}
