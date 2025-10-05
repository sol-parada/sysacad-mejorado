using Microsoft.AspNetCore.Mvc;
using SysacadMejorado.Models;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        // GET: api/alumnos
        [HttpGet]
        public IActionResult GetAlumnos()
        {
            var alumnos = new List<Alumno>
            {
                new Alumno
                {
                    Apellido = "García",
                    Nombre = "Ana",
                    NroDocumento = "40123456",
                    TipoDocumento = TipoDocumento.DNI,
                    FechaNacimiento = new DateTime(2000, 5, 15),
                    Sexo = "Femenino",
                    NroLegajo = 12345,
                    FechaIngreso = new DateTime(2023, 3, 1)
                },
                new Alumno
                {
                    Apellido = "López",
                    Nombre = "Carlos",
                    NroDocumento = "35123456",
                    TipoDocumento = TipoDocumento.DNI,
                    FechaNacimiento = new DateTime(1999, 8, 22),
                    Sexo = "Masculino",
                    NroLegajo = 12346,
                    FechaIngreso = new DateTime(2023, 3, 1)
                },
                new Alumno
                {
                    Apellido = "Rodríguez",
                    Nombre = "María",
                    NroDocumento = "38987654",
                    TipoDocumento = TipoDocumento.DNI,
                    FechaNacimiento = new DateTime(2001, 3, 10),
                    Sexo = "Femenino",
                    NroLegajo = 12347,
                    FechaIngreso = new DateTime(2023, 3, 1)
                }
            };

            return Ok(alumnos);
        }

        // GET: api/alumnos/12345
        [HttpGet("{nroLegajo}")]
        public IActionResult GetAlumno(int nroLegajo)
        {
            // Simulamos buscar un alumno por su número de legajo
            var alumno = new Alumno
            {
                Apellido = "García",
                Nombre = "Ana",
                NroDocumento = "40123456",
                TipoDocumento = TipoDocumento.DNI,
                FechaNacimiento = new DateTime(2000, 5, 15),
                Sexo = "Femenino",
                NroLegajo = nroLegajo,
                FechaIngreso = new DateTime(2023, 3, 1)
            };

            return Ok(alumno);
        }

        // POST: api/alumnos
        [HttpPost]
        public IActionResult CrearAlumno([FromBody] Alumno nuevoAlumno)
        {
            // Aquí normalmente guardaríamos en la base de datos
            // Por ahora solo devolvemos el alumno creado
            return Ok(new
            {
                mensaje = "Alumno creado exitosamente",
                alumno = nuevoAlumno
            });
        }
        // PUT: api/alumnos/12345
        [HttpPut("{nroLegajo}")]
        public IActionResult ActualizarAlumno(int nroLegajo, [FromBody] Alumno alumnoActualizado)
        {
            // En una versión real, buscaríamos y actualizaríamos en la base de datos
            return Ok(new
            {
                mensaje = $"Alumno con legajo {nroLegajo} actualizado exitosamente",
                alumno = alumnoActualizado
            });
        }

        // DELETE: api/alumnos/12345
        [HttpDelete("{nroLegajo}")]
        public IActionResult EliminarAlumno(int nroLegajo)
        {
            // En una versión real, eliminaríamos de la base de datos
            return Ok(new
            {
                mensaje = $"Alumno con legajo {nroLegajo} eliminado exitosamente",
                nroLegajo = nroLegajo
            });
        }
    }
}