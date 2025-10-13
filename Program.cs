using Microsoft.EntityFrameworkCore;
using SysAcadMejorado;
using SysAcadMejorado.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar PostgreSQL con logging detallado
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()
           .EnableDetailedErrors());

// Registrar tus servicios (solo uno por tipo, usa Scoped para servicios con DbContext)
builder.Services.AddScoped<AutoridadService>();
builder.Services.AddScoped<AlumnoService>();
builder.Services.AddScoped<UniversidadService>();
builder.Services.AddScoped<FacultadService>();
builder.Services.AddScoped<MateriaService>();

// Configurar logging
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

public partial class Program { }