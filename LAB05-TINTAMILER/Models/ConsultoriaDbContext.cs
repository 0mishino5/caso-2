using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAB05_TINTAMILER.Models;

public partial class ConsultoriaDbContext : DbContext
{
    public ConsultoriaDbContext(DbContextOptions<ConsultoriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comunicacionescliente> Comunicacionesclientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Hitosproyecto> Hitosproyectos { get; set; }

    public virtual DbSet<Informesprogreso> Informesprogresos { get; set; }

    public virtual DbSet<Presupuestosproyecto> Presupuestosproyectos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Tareasproyecto> Tareasproyectos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Clienteid).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Correo, "IX_clientes_correo").IsUnique();

            entity.HasIndex(e => e.Ruc, "IX_clientes_ruc").IsUnique();

            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Razonsocial)
                .HasMaxLength(150)
                .HasColumnName("razonsocial");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Comunicacionescliente>(entity =>
        {
            entity.HasKey(e => e.Comunicacionclienteid).HasName("comunicacionescliente_pkey");

            entity.ToTable("comunicacionescliente");

            entity.HasIndex(e => e.Clienteid, "IX_comunicacionescliente_clienteid");

            entity.HasIndex(e => e.Proyectoid, "IX_comunicacionescliente_proyectoid");

            entity.Property(e => e.Comunicacionclienteid).HasColumnName("comunicacionclienteid");
            entity.Property(e => e.Asunto)
                .HasMaxLength(150)
                .HasColumnName("asunto");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Detalle)
                .HasMaxLength(1000)
                .HasColumnName("detalle");
            entity.Property(e => e.Fechacomunicacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacomunicacion");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Registradopor)
                .HasMaxLength(120)
                .HasColumnName("registradopor");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Comunicacionesclientes)
                .HasForeignKey(d => d.Clienteid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comunicaciones_clientes");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Comunicacionesclientes)
                .HasForeignKey(d => d.Proyectoid)
                .HasConstraintName("fk_comunicaciones_proyectos");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Empleadoid).HasName("empleados_pkey");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Correo, "IX_empleados_correo").IsUnique();

            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cargo)
                .HasMaxLength(80)
                .HasColumnName("cargo");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Hitosproyecto>(entity =>
        {
            entity.HasKey(e => e.Hitoproyectoid).HasName("hitosproyecto_pkey");

            entity.ToTable("hitosproyecto");

            entity.HasIndex(e => e.Proyectoid, "IX_hitosproyecto_proyectoid");

            entity.Property(e => e.Hitoproyectoid).HasColumnName("hitoproyectoid");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fechacumplimiento).HasColumnName("fechacumplimiento");
            entity.Property(e => e.Fechaplanificada).HasColumnName("fechaplanificada");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Hitosproyectos)
                .HasForeignKey(d => d.Proyectoid)
                .HasConstraintName("fk_hitos_proyectos");
        });

        modelBuilder.Entity<Informesprogreso>(entity =>
        {
            entity.HasKey(e => e.Informeprogresoid).HasName("informesprogreso_pkey");

            entity.ToTable("informesprogreso");

            entity.HasIndex(e => e.Empleadoid, "IX_informesprogreso_empleadoid");

            entity.HasIndex(e => e.Proyectoid, "IX_informesprogreso_proyectoid");

            entity.Property(e => e.Informeprogresoid).HasColumnName("informeprogresoid");
            entity.Property(e => e.Avancegeneral).HasColumnName("avancegeneral");
            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Fechainforme).HasColumnName("fechainforme");
            entity.Property(e => e.Hitosalcanzados)
                .HasMaxLength(1000)
                .HasColumnName("hitosalcanzados");
            entity.Property(e => e.Pendientes)
                .HasMaxLength(1000)
                .HasColumnName("pendientes");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Riesgos)
                .HasMaxLength(1000)
                .HasColumnName("riesgos");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Informesprogresos)
                .HasForeignKey(d => d.Empleadoid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_informes_empleados");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Informesprogresos)
                .HasForeignKey(d => d.Proyectoid)
                .HasConstraintName("fk_informes_proyectos");
        });

        modelBuilder.Entity<Presupuestosproyecto>(entity =>
        {
            entity.HasKey(e => e.Presupuestoproyectoid).HasName("presupuestosproyecto_pkey");

            entity.ToTable("presupuestosproyecto");

            entity.HasIndex(e => e.Proyectoid, "IX_presupuestosproyecto_proyectoid");

            entity.Property(e => e.Presupuestoproyectoid).HasColumnName("presupuestoproyectoid");
            entity.Property(e => e.Concepto)
                .HasMaxLength(120)
                .HasColumnName("concepto");
            entity.Property(e => e.Fecharegistro).HasColumnName("fecharegistro");
            entity.Property(e => e.Gastoreal)
                .HasPrecision(12, 2)
                .HasColumnName("gastoreal");
            entity.Property(e => e.Montoestimado)
                .HasPrecision(12, 2)
                .HasColumnName("montoestimado");
            entity.Property(e => e.Observacion)
                .HasMaxLength(300)
                .HasColumnName("observacion");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Presupuestosproyectos)
                .HasForeignKey(d => d.Proyectoid)
                .HasConstraintName("fk_presupuestos_proyectos");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Proyectoid).HasName("proyectos_pkey");

            entity.ToTable("proyectos");

            entity.HasIndex(e => e.Clienteid, "IX_proyectos_clienteid");

            entity.HasIndex(e => e.Responsableid, "IX_proyectos_responsableid");

            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Planificado'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fechafin).HasColumnName("fechafin");
            entity.Property(e => e.Fechainicio).HasColumnName("fechainicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Objetivos)
                .HasMaxLength(500)
                .HasColumnName("objetivos");
            entity.Property(e => e.Responsableid).HasColumnName("responsableid");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Clienteid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proyectos_clientes");

            entity.HasOne(d => d.Responsable).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Responsableid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proyectos_empleados");
        });

        modelBuilder.Entity<Tareasproyecto>(entity =>
        {
            entity.HasKey(e => e.Tareaproyectoid).HasName("tareasproyecto_pkey");

            entity.ToTable("tareasproyecto");

            entity.HasIndex(e => e.Empleadoid, "IX_tareasproyecto_empleadoid");

            entity.HasIndex(e => e.Proyectoid, "IX_tareasproyecto_proyectoid");

            entity.Property(e => e.Tareaproyectoid).HasColumnName("tareaproyectoid");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fechalimite).HasColumnName("fechalimite");
            entity.Property(e => e.Porcentajeavance).HasColumnName("porcentajeavance");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Tareasproyectos)
                .HasForeignKey(d => d.Empleadoid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_tareas_empleados");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Tareasproyectos)
                .HasForeignKey(d => d.Proyectoid)
                .HasConstraintName("fk_tareas_proyectos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
