namespace LAB05_TINTAMILER.Models;

public class InformeProgreso
{
    public int InformeProgresoId { get; set; }
    public int ProyectoId { get; set; }
    public int EmpleadoId { get; set; }
    public DateOnly FechaInforme { get; set; }
    public int AvanceGeneral { get; set; }
    public string HitosAlcanzados { get; set; } = null!;
    public string Pendientes { get; set; } = null!;
    public string Riesgos { get; set; } = null!;

    public virtual Proyecto? Proyecto { get; set; }
    public virtual Empleado? Empleado { get; set; }
}
