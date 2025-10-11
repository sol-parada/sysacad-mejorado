using Microsoft.EntityFrameworkCore;
using SysAcadMejorado;
using SysAcadMejorado.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONFIGURAR POSTGRESQL CON LOGGING DETALLADO
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()  // ← AGREGAR ESTO
           .EnableDetailedErrors());      // ← Y ESTO

// REGISTRAR TUS SERVICES
builder.Services.AddScoped<AlumnoService>();
builder.Services.AddScoped<UniversidadService>();
builder.Services.AddScoped<FacultadService>();
builder.Services.AddScoped<AutoridadService>();
builder.Services.AddScoped<MateriaService>();

// CONFIGURAR LOGGING
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();