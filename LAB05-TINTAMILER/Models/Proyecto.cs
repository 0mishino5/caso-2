using System;
using System.Collections.Generic;

namespace LAB05_TINTAMILER.Models;

public partial class Proyecto
{
    public int Proyectoid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Objetivos { get; set; } = null!;

    public DateOnly Fechainicio { get; set; }

    public DateOnly? Fechafin { get; set; }

    public string Estado { get; set; } = null!;

    public int Clienteid { get; set; }

    public int Responsableid { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Comunicacionescliente> Comunicacionesclientes { get; set; } = new List<Comunicacionescliente>();

    public virtual ICollection<Hitosproyecto> Hitosproyectos { get; set; } = new List<Hitosproyecto>();

    public virtual ICollection<Informesprogreso> Informesprogresos { get; set; } = new List<Informesprogreso>();

    public virtual ICollection<Presupuestosproyecto> Presupuestosproyectos { get; set; } = new List<Presupuestosproyecto>();

    public virtual Empleado Responsable { get; set; } = null!;

    public virtual ICollection<Tareasproyecto> Tareasproyectos { get; set; } = new List<Tareasproyecto>();
}
