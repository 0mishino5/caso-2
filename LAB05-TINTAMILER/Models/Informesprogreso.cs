using System;
using System.Collections.Generic;

namespace LAB05_TINTAMILER.Models;

public partial class Informesprogreso
{
    public int Informeprogresoid { get; set; }

    public int Proyectoid { get; set; }

    public int Empleadoid { get; set; }

    public DateOnly Fechainforme { get; set; }

    public int Avancegeneral { get; set; }

    public string Hitosalcanzados { get; set; } = null!;

    public string Pendientes { get; set; } = null!;

    public string Riesgos { get; set; } = null!;

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
