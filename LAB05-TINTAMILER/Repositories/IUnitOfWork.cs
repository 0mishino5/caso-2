using LAB05_TINTAMILER.Repositories.Interfaces;

namespace LAB05_TINTAMILER.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    IEmpleadoRepository Empleados { get; }
    IProyectoRepository Proyectos { get; }
    ITareaProyectoRepository TareasProyecto { get; }
    IPresupuestoProyectoRepository PresupuestosProyecto { get; }
    IComunicacionClienteRepository ComunicacionesCliente { get; }
    IInformeProgresoRepository InformesProgreso { get; }
    IHitoProyectoRepository HitosProyecto { get; }
    Task<int> SaveAsync();
}
