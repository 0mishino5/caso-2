using System;
using System.Collections.Generic;

namespace LAB05_TINTAMILER.Models;

public partial class Tareasproyecto
{
    public int Tareaproyectoid { get; set; }

    public int Proyectoid { get; set; }

    public int Empleadoid { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly Fechalimite { get; set; }

    public string Estado { get; set; } = null!;

    public int Porcentajeavance { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
