using Microsoft.EntityFrameworkCore;

namespace LAB05_TINTAMILER.Models;

public class ConsultoriaDbContext : DbContext
{
    public ConsultoriaDbContext()
    {
    }

    public ConsultoriaDbContext(DbContextOptions<ConsultoriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<Proyecto> Proyectos { get; set; }
    public virtual DbSet<TareaProyecto> TareasProyecto { get; set; }
    public virtual DbSet<PresupuestoProyecto> PresupuestosProyecto { get; set; }
    public virtual DbSet<ComunicacionCliente> ComunicacionesCliente { get; set; }
    public virtual DbSet<InformeProgreso> InformesProgreso { get; set; }
    public virtual DbSet<HitoProyecto> HitosProyecto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("clientes_pkey");
            entity.ToTable("clientes");
            entity.HasIndex(e => e.Ruc).IsUnique();
            entity.HasIndex(e => e.Correo).IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("clienteid");
            entity.Property(e => e.RazonSocial).HasMaxLength(150).HasColumnName("razonsocial");
            entity.Property(e => e.Ruc).HasMaxLength(11).HasColumnName("ruc");
            entity.Property(e => e.Correo).HasMaxLength(120).HasColumnName("correo");
            entity.Property(e => e.Telefono).HasMaxLength(20).HasColumnName("telefono");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp without time zone").HasColumnName("fecharegistro");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("empleados_pkey");
            entity.ToTable("empleados");
            entity.HasIndex(e => e.Correo).IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("empleadoid");
            entity.Property(e => e.Nombres).HasMaxLength(100).HasColumnName("nombres");
            entity.Property(e => e.Apellidos).HasMaxLength(100).HasColumnName("apellidos");
            entity.Property(e => e.Cargo).HasMaxLength(80).HasColumnName("cargo");
            entity.Property(e => e.Correo).HasMaxLength(120).HasColumnName("correo");
            entity.Property(e => e.Activo).HasDefaultValue(true).HasColumnName("activo");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.ProyectoId).HasName("proyectos_pkey");
            entity.ToTable("proyectos");

            entity.Property(e => e.ProyectoId).HasColumnName("proyectoid");
            entity.Property(e => e.Nombre).HasMaxLength(150).HasColumnName("nombre");
            entity.Property(e => e.Objetivos).HasMaxLength(500).HasColumnName("objetivos");
            entity.Property(e => e.FechaInicio).HasColumnName("fechainicio");
            entity.Property(e => e.FechaFin).HasColumnName("fechafin");
            entity.Property(e => e.Estado).HasMaxLength(30).HasDefaultValue("Planificado").HasColumnName("estado");
            entity.Property(e => e.ClienteId).HasColumnName("clienteid");
            entity.Property(e => e.ResponsableId).HasColumnName("responsableid");

            entity.HasOne(e => e.Cliente).WithMany(e => e.Proyectos)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proyectos_clientes");

            entity.HasOne(e => e.Responsable).WithMany(e => e.ProyectosResponsables)
                .HasForeignKey(e => e.ResponsableId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proyectos_empleados");
        });

        modelBuilder.Entity<TareaProyecto>(entity =>
        {
            entity.HasKey(e => e.TareaProyectoId).HasName("tareasproyecto_pkey");
            entity.ToTable("tareasproyecto", t => t.HasCheckConstraint("ck_tareas_avance", "porcentajeavance >= 0 AND porcentajeavance <= 100"));

            entity.Property(e => e.TareaProyectoId).HasColumnName("tareaproyectoid");
            entity.Property(e => e.ProyectoId).HasColumnName("proyectoid");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleadoid");
            entity.Property(e => e.Titulo).HasMaxLength(150).HasColumnName("titulo");
            entity.Property(e => e.Descripcion).HasMaxLength(500).HasColumnName("descripcion");
            entity.Property(e => e.FechaLimite).HasColumnName("fechalimite");
            entity.Property(e => e.Estado).HasMaxLength(30).HasDefaultValue("Pendiente").HasColumnName("estado");
            entity.Property(e => e.PorcentajeAvance).HasColumnName("porcentajeavance");

            entity.HasOne(e => e.Proyecto).WithMany(e => e.Tareas)
                .HasForeignKey(e => e.ProyectoId)
                .HasConstraintName("fk_tareas_proyectos");

            entity.HasOne(e => e.Empleado).WithMany(e => e.TareasAsignadas)
                .HasForeignKey(e => e.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_tareas_empleados");
        });

        modelBuilder.Entity<PresupuestoProyecto>(entity =>
        {
            entity.HasKey(e => e.PresupuestoProyectoId).HasName("presupuestosproyecto_pkey");
            entity.ToTable("presupuestosproyecto", t =>
            {
                t.HasCheckConstraint("ck_presupuesto_estimado", "montoestimado >= 0");
                t.HasCheckConstraint("ck_presupuesto_gasto", "gastoreal >= 0");
            });

            entity.Property(e => e.PresupuestoProyectoId).HasColumnName("presupuestoproyectoid");
            entity.Property(e => e.ProyectoId).HasColumnName("proyectoid");
            entity.Property(e => e.Concepto).HasMaxLength(120).HasColumnName("concepto");
            entity.Property(e => e.MontoEstimado).HasPrecision(12, 2).HasColumnName("montoestimado");
            entity.Property(e => e.GastoReal).HasPrecision(12, 2).HasColumnName("gastoreal");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Observacion).HasMaxLength(300).HasColumnName("observacion");

            entity.HasOne(e => e.Proyecto).WithMany(e => e.Presupuestos)
                .HasForeignKey(e => e.ProyectoId)
                .HasConstraintName("fk_presupuestos_proyectos");
        });

        modelBuilder.Entity<ComunicacionCliente>(entity =>
        {
            entity.HasKey(e => e.ComunicacionClienteId).HasName("comunicacionescliente_pkey");
            entity.ToTable("comunicacionescliente");

            entity.Property(e => e.ComunicacionClienteId).HasColumnName("comunicacionclienteid");
            entity.Property(e => e.ClienteId).HasColumnName("clienteid");
            entity.Property(e => e.ProyectoId).HasColumnName("proyectoid");
            entity.Property(e => e.Tipo).HasMaxLength(50).HasColumnName("tipo");
            entity.Property(e => e.Asunto).HasMaxLength(150).HasColumnName("asunto");
            entity.Property(e => e.Detalle).HasMaxLength(1000).HasColumnName("detalle");
            entity.Property(e => e.FechaComunicacion).HasColumnType("timestamp without time zone").HasColumnName("fechacomunicacion");
            entity.Property(e => e.RegistradoPor).HasMaxLength(120).HasColumnName("registradopor");

            entity.HasOne(e => e.Cliente).WithMany(e => e.Comunicaciones)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comunicaciones_clientes");

            entity.HasOne(e => e.Proyecto).WithMany(e => e.Comunicaciones)
                .HasForeignKey(e => e.ProyectoId)
                .HasConstraintName("fk_comunicaciones_proyectos");
        });

        modelBuilder.Entity<InformeProgreso>(entity =>
        {
            entity.HasKey(e => e.InformeProgresoId).HasName("informesprogreso_pkey");
            entity.ToTable("informesprogreso", t => t.HasCheckConstraint("ck_informes_avance", "avancegeneral >= 0 AND avancegeneral <= 100"));

            entity.Property(e => e.InformeProgresoId).HasColumnName("informeprogresoid");
            entity.Property(e => e.ProyectoId).HasColumnName("proyectoid");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleadoid");
            entity.Property(e => e.FechaInforme).HasColumnName("fechainforme");
            entity.Property(e => e.AvanceGeneral).HasColumnName("avancegeneral");
            entity.Property(e => e.HitosAlcanzados).HasMaxLength(1000).HasColumnName("hitosalcanzados");
            entity.Property(e => e.Pendientes).HasMaxLength(1000).HasColumnName("pendientes");
            entity.Property(e => e.Riesgos).HasMaxLength(1000).HasColumnName("riesgos");

            entity.HasOne(e => e.Proyecto).WithMany(e => e.Informes)
                .HasForeignKey(e => e.ProyectoId)
                .HasConstraintName("fk_informes_proyectos");

            entity.HasOne(e => e.Empleado).WithMany(e => e.InformesEmitidos)
                .HasForeignKey(e => e.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_informes_empleados");
        });

        modelBuilder.Entity<HitoProyecto>(entity =>
        {
            entity.HasKey(e => e.HitoProyectoId).HasName("hitosproyecto_pkey");
            entity.ToTable("hitosproyecto");

            entity.Property(e => e.HitoProyectoId).HasColumnName("hitoproyectoid");
            entity.Property(e => e.ProyectoId).HasColumnName("proyectoid");
            entity.Property(e => e.Nombre).HasMaxLength(150).HasColumnName("nombre");
            entity.Property(e => e.FechaPlanificada).HasColumnName("fechaplanificada");
            entity.Property(e => e.FechaCumplimiento).HasColumnName("fechacumplimiento");
            entity.Property(e => e.Estado).HasMaxLength(30).HasDefaultValue("Pendiente").HasColumnName("estado");

            entity.HasOne(e => e.Proyecto).WithMany(e => e.Hitos)
                .HasForeignKey(e => e.ProyectoId)
                .HasConstraintName("fk_hitos_proyectos");
        });
    }
}
