namespace LAB05_TINTAMILER.Models;

public class ComunicacionCliente
{
    public int ComunicacionClienteId { get; set; }
    public int ClienteId { get; set; }
    public int ProyectoId { get; set; }
    public string Tipo { get; set; } = null!;
    public string Asunto { get; set; } = null!;
    public string Detalle { get; set; } = null!;
    public DateTime FechaComunicacion { get; set; }
    public string RegistradoPor { get; set; } = null!;

    public virtual Cliente? Cliente { get; set; }
    public virtual Proyecto? Proyecto { get; set; }
}
