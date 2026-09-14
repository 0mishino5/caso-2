using System.Text.Json.Serialization;
using caso2_3integrantes.Models;
using caso2_3integrantes.Repositories;
using caso2_3integrantes.Repositories.Implementations;
using caso2_3integrantes.Services.Implementations;
using caso2_3integrantes.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConsultoriaDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();
builder.Services.AddScoped<ITareaProyectoRepository, TareaProyectoRepository>();
builder.Services.AddScoped<IPresupuestoProyectoRepository, PresupuestoProyectoRepository>();
builder.Services.AddScoped<IComunicacionClienteRepository, ComunicacionClienteRepository>();
builder.Services.AddScoped<IInformeProgresoRepository, InformeProgresoRepository>();
builder.Services.AddScoped<IHitoProyectoRepository, HitoProyectoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IProyectoService, ProyectoService>();
builder.Services.AddScoped<ITareaProyectoService, TareaProyectoService>();
builder.Services.AddScoped<IPresupuestoProyectoService, PresupuestoProyectoService>();
builder.Services.AddScoped<IComunicacionClienteService, ComunicacionClienteService>();
builder.Services.AddScoped<IInformeProgresoService, InformeProgresoService>();
builder.Services.AddScoped<IHitoProyectoService, HitoProyectoService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "caso2-3integrantes API",
        Version = "v1",
        Description = "API para la gestion de proyectos de una empresa de consultoria."
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "caso2-3integrantes API v1");
});

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is KeyNotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(new { mensaje = exception.Message });
            return;
        }

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new { mensaje = "Ocurrio un error en el servidor." });
    });
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
