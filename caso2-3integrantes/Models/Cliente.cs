using System;
using System.Collections.Generic;

namespace caso2_3integrantes.Models;

public partial class Cliente
{
    public int Clienteid { get; set; }

    public string Razonsocial { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime Fecharegistro { get; set; }

    public virtual ICollection<Comunicacionescliente> Comunicacionesclientes { get; set; } = new List<Comunicacionescliente>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
