using SysAcadMejorado.Models;
using Microsoft.EntityFrameworkCore;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class AlumnoService
    {
        private readonly AppDbContext _context;

        // INYECCIÓN DE DEPENDENCIAS - Entity Framework
        public AlumnoService(AppDbContext context)
        {
            _context = context;
        }

        // GET: Todos los alumnos (ASINCRÓNICO)
        public async Task<List<Alumno>> ObtenerTodos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        // GET: Alumno por legajo (ASINCRÓNICO)
        public async Task<Alumno?> ObtenerPorLegajo(int legajo)
        {
            return await _context.Alumnos
                .FirstOrDefaultAsync(a => a.NroLegajo == legajo);
        }

        // GET: Alumno por ID (ASINCRÓNICO)
        public async Task<Alumno?> ObtenerPorId(int id)
        {
            return await _context.Alumnos
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // POST: Crear alumno (ASINCRÓNICO)
        public async Task<Alumno> CrearAlumno(Alumno alumno)
        {
            try
            {
                // VALIDACIÓN: No puede existir otro con mismo legajo
                var alumnoExistente = await ObtenerPorLegajo(alumno.NroLegajo);
                if (alumnoExistente != null)
                {
                    throw new Exception($"Ya existe un alumno con el legajo {alumno.NroLegajo}");
                }

                // VALIDACIÓN: Debe ser mayor de 16 años
                if (DateTime.Now.Year - alumno.FechaNacimiento.Year < 16)
                {
                    throw new Exception("El alumno debe tener al menos 16 años");
                }

                // AGREGAR Y GUARDAR EN BD
                _context.Alumnos.Add(alumno);
                await _context.SaveChangesAsync();

                return alumno;
            }
            catch (DbUpdateException dbEx)
            {
                // CAPTURAR ERROR DE BASE DE DATOS COMPLETO
                throw new Exception($"Error de base de datos: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        // PUT: Actualizar alumno (ASINCRÓNICO)
        public async Task<Alumno> ActualizarAlumno(int id, Alumno alumnoActualizado)
        {
            try
            {
                var alumnoExistente = await ObtenerPorId(id);
                if (alumnoExistente == null)
                {
                    throw new Exception($"No se encontró alumno con ID {id}");
                }

                // VALIDACIÓN: Si cambia el legajo, verificar que no exista otro
                if (alumnoExistente.NroLegajo != alumnoActualizado.NroLegajo)
                {
                    var alumnoConMismoLegajo = await ObtenerPorLegajo(alumnoActualizado.NroLegajo);
                    if (alumnoConMismoLegajo != null)
                    {
                        throw new Exception($"Ya existe otro alumno con el legajo {alumnoActualizado.NroLegajo}");
                    }
                }

                // ACTUALIZAR PROPIEDADES
                alumnoExistente.Apellido = alumnoActualizado.Apellido;
                alumnoExistente.Nombre = alumnoActualizado.Nombre;
                alumnoExistente.NroDocumento = alumnoActualizado.NroDocumento;
                alumnoExistente.TipoDocumento = alumnoActualizado.TipoDocumento;
                alumnoExistente.FechaNacimiento = alumnoActualizado.FechaNacimiento;
                alumnoExistente.Sexo = alumnoActualizado.Sexo;
                alumnoExistente.NroLegajo = alumnoActualizado.NroLegajo;
                alumnoExistente.FechaIngreso = alumnoActualizado.FechaIngreso;

                // GUARDAR CAMBIOS EN BD
                await _context.SaveChangesAsync();

                return alumnoExistente;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error de base de datos al actualizar: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        // DELETE: Eliminar alumno (ASINCRÓNICO)
        public async Task<bool> EliminarAlumno(int id)
        {
            try
            {
                var alumno = await ObtenerPorId(id);
                if (alumno == null)
                {
                    throw new Exception($"No se encontró alumno con ID {id}");
                }

                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error de base de datos al eliminar: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}