using System;
using System.Collections.Generic;

namespace caso2_3integrantes.Models;

public partial class Hitosproyecto
{
    public int Hitoproyectoid { get; set; }

    public int Proyectoid { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly Fechaplanificada { get; set; }

    public DateOnly? Fechacumplimiento { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
