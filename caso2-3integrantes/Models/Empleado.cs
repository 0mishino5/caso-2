using System;
using System.Collections.Generic;

namespace caso2_3integrantes.Models;

public partial class Empleado
{
    public int Empleadoid { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Informesprogreso> Informesprogresos { get; set; } = new List<Informesprogreso>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Tareasproyecto> Tareasproyectos { get; set; } = new List<Tareasproyecto>();
}
