using System;
using System.Collections.Generic;

namespace LAB05_TINTAMILER.Models;

public partial class Comunicacionescliente
{
    public int Comunicacionclienteid { get; set; }

    public int Clienteid { get; set; }

    public int Proyectoid { get; set; }

    public string Tipo { get; set; } = null!;

    public string Asunto { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public DateTime Fechacomunicacion { get; set; }

    public string Registradopor { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
