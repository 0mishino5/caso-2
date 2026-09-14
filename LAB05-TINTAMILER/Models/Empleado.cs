namespace LAB05_TINTAMILER.Models;

public class Empleado
{
    public int EmpleadoId { get; set; }
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Cargo { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public bool Activo { get; set; }

    public virtual ICollection<Proyecto> ProyectosResponsables { get; set; } = new List<Proyecto>();
    public virtual ICollection<TareaProyecto> TareasAsignadas { get; set; } = new List<TareaProyecto>();
    public virtual ICollection<InformeProgreso> InformesEmitidos { get; set; } = new List<InformeProgreso>();
}
