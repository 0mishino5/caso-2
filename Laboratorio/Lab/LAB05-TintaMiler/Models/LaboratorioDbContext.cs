using Microsoft.EntityFrameworkCore;

namespace LAB05_TintaMiler.Models;

public class LaboratorioDbContext : DbContext
{
    public LaboratorioDbContext(DbContextOptions<LaboratorioDbContext> options)
        : base(options)
    {
    }

    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Profesor> Profesores => Set<Profesor>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Evaluacion> Evaluaciones => Set<Evaluacion>();
    public DbSet<Asistencia> Asistencias => Set<Asistencia>();
    public DbSet<Materia> Materias => Set<Materia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.ToTable("estudiantes");
            entity.HasKey(e => e.IdEstudiante);
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Edad).HasColumnName("edad").IsRequired();
            entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255);
            entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20);
            entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(100);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.ToTable("cursos");
            entity.HasKey(e => e.IdCurso);
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Creditos).HasColumnName("creditos").IsRequired();
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.ToTable("profesores");
            entity.HasKey(e => e.IdProfesor);
            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Especialidad).HasColumnName("especialidad").HasMaxLength(100);
            entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(100);
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.ToTable("matriculas");
            entity.HasKey(e => e.IdMatricula);
            entity.Property(e => e.IdMatricula).HasColumnName("id_matricula");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Semestre).HasColumnName("semestre").HasMaxLength(20);

            entity.HasOne(e => e.Estudiante)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(e => e.IdEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Curso)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(e => e.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.ToTable("evaluaciones");
            entity.HasKey(e => e.IdEvaluacion);
            entity.Property(e => e.IdEvaluacion).HasColumnName("id_evaluacion");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion").HasColumnType("decimal(5,2)");
            entity.Property(e => e.Fecha).HasColumnName("fecha");

            entity.HasOne(e => e.Estudiante)
                .WithMany(e => e.Evaluaciones)
                .HasForeignKey(e => e.IdEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Curso)
                .WithMany(e => e.Evaluaciones)
                .HasForeignKey(e => e.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.ToTable("asistencias", table =>
                table.HasCheckConstraint("ck_asistencias_estado", "estado IN ('Presente', 'Ausente', 'Justificada')"));
            entity.HasKey(e => e.IdAsistencia);
            entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");
            entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(20);

            entity.HasOne(e => e.Estudiante)
                .WithMany(e => e.Asistencias)
                .HasForeignKey(e => e.IdEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Curso)
                .WithMany(e => e.Asistencias)
                .HasForeignKey(e => e.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.ToTable("materias");
            entity.HasKey(e => e.IdMateria);
            entity.Property(e => e.IdMateria).HasColumnName("id_materia");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");

            entity.HasOne(e => e.Curso)
                .WithMany(e => e.Materias)
                .HasForeignKey(e => e.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
