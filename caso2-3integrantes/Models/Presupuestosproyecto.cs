using System;
using System.Collections.Generic;

namespace caso2_3integrantes.Models;

public partial class Presupuestosproyecto
{
    public int Presupuestoproyectoid { get; set; }

    public int Proyectoid { get; set; }

    public string Concepto { get; set; } = null!;

    public decimal Montoestimado { get; set; }

    public decimal Gastoreal { get; set; }

    public DateOnly Fecharegistro { get; set; }

    public string Observacion { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
