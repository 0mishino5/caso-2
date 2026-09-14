namespace LAB05_TINTAMILER.Models;

public class HitoProyecto
{
    public int HitoProyectoId { get; set; }
    public int ProyectoId { get; set; }
    public string Nombre { get; set; } = null!;
    public DateOnly FechaPlanificada { get; set; }
    public DateOnly? FechaCumplimiento { get; set; }
    public string Estado { get; set; } = null!;

    public virtual Proyecto? Proyecto { get; set; }
}
