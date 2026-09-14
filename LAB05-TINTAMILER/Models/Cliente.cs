namespace LAB05_TINTAMILER.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    public string RazonSocial { get; set; } = null!;
    public string Ruc { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
    public virtual ICollection<ComunicacionCliente> Comunicaciones { get; set; } = new List<ComunicacionCliente>();
}
