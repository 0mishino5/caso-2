namespace LAB05_TintaMiler.Models;

public class Materia
{
    public int IdMateria { get; set; }
    public int IdCurso { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public Curso? Curso { get; set; }
}
