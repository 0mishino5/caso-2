# LAB05 TINTAMILER

API ASP.NET Core para el Caso 2: Empresa de Servicios de Consultoria - Gestion de Proyectos.

## Estructura por capas

- `Models`: entidades, relaciones y configuracion de tablas en `ConsultoriaDbContext`.
- `Repositories`: acceso a datos mediante repositorios e `IUnitOfWork`.
- `Services`: reglas y operaciones CRUD separadas del controlador.
- `Controllers`: endpoints REST para probar desde Swagger.
- `Migrations`: migracion inicial para crear la base de datos PostgreSQL.

## Entidades principales

- `Cliente`: empresas atendidas por la consultora.
- `Empleado`: responsables y asignados a proyectos, tareas e informes.
- `Proyecto`: fechas, estado, objetivos, cliente y responsable.
- `TareaProyecto`: asignacion de tareas con fecha limite y porcentaje de avance.
- `PresupuestoProyecto`: presupuesto estimado y gasto real por concepto.
- `ComunicacionCliente`: registro de correos, reuniones e interacciones.
- `InformeProgreso`: avance general, hitos alcanzados, pendientes y riesgos.
- `HitoProyecto`: hitos planificados y cumplidos del proyecto.

## Comandos utiles

```bash
dotnet build
dotnet ef database update
dotnet run
```

Al ejecutar el proyecto, Swagger queda disponible desde la URL local que muestre Rider o la terminal.
