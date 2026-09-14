namespace LAB05_TINTAMILER.Models;

public class TareaProyecto
{
    public int TareaProyectoId { get; set; }
    public int ProyectoId { get; set; }
    public int EmpleadoId { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public DateOnly FechaLimite { get; set; }
    public string Estado { get; set; } = null!;
    public int PorcentajeAvance { get; set; }

    public virtual Proyecto? Proyecto { get; set; }
    public virtual Empleado? Empleado { get; set; }
}
