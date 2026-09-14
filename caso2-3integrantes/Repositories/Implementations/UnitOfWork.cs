using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;

namespace caso2_3integrantes.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly ConsultoriaDbContext _context;

    public UnitOfWork(ConsultoriaDbContext context)
    {
        _context = context;
        Clientes = new ClienteRepository(_context);
        Empleados = new EmpleadoRepository(_context);
        Proyectos = new ProyectoRepository(_context);
        TareasProyecto = new TareaProyectoRepository(_context);
        PresupuestosProyecto = new PresupuestoProyectoRepository(_context);
        ComunicacionesCliente = new ComunicacionClienteRepository(_context);
        InformesProgreso = new InformeProgresoRepository(_context);
        HitosProyecto = new HitoProyectoRepository(_context);
    }

    public IClienteRepository Clientes { get; }
    public IEmpleadoRepository Empleados { get; }
    public IProyectoRepository Proyectos { get; }
    public ITareaProyectoRepository TareasProyecto { get; }
    public IPresupuestoProyectoRepository PresupuestosProyecto { get; }
    public IComunicacionClienteRepository ComunicacionesCliente { get; }
    public IInformeProgresoRepository InformesProgreso { get; }
    public IHitoProyectoRepository HitosProyecto { get; }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
