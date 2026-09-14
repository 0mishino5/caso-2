namespace LAB05_TINTAMILER.Models;

public class PresupuestoProyecto
{
    public int PresupuestoProyectoId { get; set; }
    public int ProyectoId { get; set; }
    public string Concepto { get; set; } = null!;
    public decimal MontoEstimado { get; set; }
    public decimal GastoReal { get; set; }
    public DateOnly FechaRegistro { get; set; }
    public string Observacion { get; set; } = null!;

    public virtual Proyecto? Proyecto { get; set; }
}
