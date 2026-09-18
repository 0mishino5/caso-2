namespace LAB05_TintaMiler.Models;

public class Estudiante
{
    public int IdEstudiante { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }

    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    public ICollection<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    public ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
}
