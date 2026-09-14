namespace caso2_3integrantes.Repositories;

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
