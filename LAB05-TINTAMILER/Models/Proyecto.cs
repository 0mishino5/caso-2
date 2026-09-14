namespace LAB05_TINTAMILER.Models;

public class Proyecto
{
    public int ProyectoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Objetivos { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public string Estado { get; set; } = null!;
    public int ClienteId { get; set; }
    public int ResponsableId { get; set; }

    public virtual Cliente? Cliente { get; set; }
    public virtual Empleado? Responsable { get; set; }
    public virtual ICollection<TareaProyecto> Tareas { get; set; } = new List<TareaProyecto>();
    public virtual ICollection<PresupuestoProyecto> Presupuestos { get; set; } = new List<PresupuestoProyecto>();
    public virtual ICollection<ComunicacionCliente> Comunicaciones { get; set; } = new List<ComunicacionCliente>();
    public virtual ICollection<InformeProgreso> Informes { get; set; } = new List<InformeProgreso>();
    public virtual ICollection<HitoProyecto> Hitos { get; set; } = new List<HitoProyecto>();
}
