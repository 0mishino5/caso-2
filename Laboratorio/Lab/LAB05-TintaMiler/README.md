# LAB05-TintaMiler

Proyecto REST API en ASP.NET Core para el Laboratorio 05.

## Incluye

- Swagger configurado.
- EF Core con PostgreSQL.
- Modelos para Estudiantes, Cursos, Profesores, Matriculas, Evaluaciones, Asistencias y Materias.
- Repositorio generico unico para todas las entidades.
- UnitOfWork con repositorios por tipo, guardado y transacciones.
- Servicios y controladores CRUD por entidad.
- Endpoints extra para matricular estudiantes y revisar el detalle de un curso.

## Cadena de conexion

La conexion esta en `appsettings.json`:

```json
"DefaultConnection": "Host=localhost;Port=5432;Database=lab05_db;Username=postgres;Password=postgres"
```

Cambia el password si tu PostgreSQL usa otra clave.

## Crear la base en PostgreSQL

Desde pgAdmin:

1. Crea una base de datos llamada `lab05_db`.
2. Abre Query Tool sobre esa base.
3. Ejecuta primero el archivo `db.sql`.
4. Ejecuta despues el archivo `insert.sql`.

Desde terminal:

```powershell
createdb -U postgres lab05_db
psql -U postgres -d lab05_db -f "C:\CURSOS UNI E INSTI\TECSUP 6 SEMESTRE\Desarrollo de Aplicaciones Empresariales Avanzado\SEMANA 5\Laboratorio\db.sql"
psql -U postgres -d lab05_db -f "C:\CURSOS UNI E INSTI\TECSUP 6 SEMESTRE\Desarrollo de Aplicaciones Empresariales Avanzado\SEMANA 5\Laboratorio\insert.sql"
```

## Ejecutar

```powershell
dotnet run
```

Luego abre Swagger en la URL que muestre la consola, normalmente:

```text
http://localhost:5188/swagger
```

## Endpoints principales

- `GET /api/estudiantes`
- `GET /api/cursos`
- `GET /api/profesores`
- `GET /api/matriculas`
- `POST /api/matriculas/matricular`
- `GET /api/matriculas/curso/{idCurso}/detalle`
- `GET /api/evaluaciones`
- `GET /api/asistencias`
- `GET /api/materias`

Nota: el SQL del laboratorio no tiene una relacion directa entre profesores y cursos. Por eso el detalle del curso devuelve docentes disponibles, pero no asigna un docente especifico a un curso.
