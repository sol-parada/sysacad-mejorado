using Microsoft.AspNetCore.Mvc;
using SysacadMejorado.Models;
using SysAcadMejorado.Models;
using SysAcadMejorado.Services;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnoService _alumnoService;

        public AlumnosController()
        {
            _alumnoService = new AlumnoService();
        }

        // GET: api/alumnos
        [HttpGet]
        public IActionResult GetAlumnos()
        {
            var alumnos = _alumnoService.ObtenerTodos();
            return Ok(alumnos);
        }

        // GET: api/alumnos/12345
        [HttpGet("{nroLegajo}")]
        public IActionResult GetAlumno(int nroLegajo)
        {
            var alumno = _alumnoService.ObtenerPorLegajo(nroLegajo);
            if (alumno == null)
                return NotFound();

            return Ok(alumno);
        }

        // POST: api/alumnos
        [HttpPost]
        public IActionResult CrearAlumno([FromBody] Alumno nuevoAlumno)
        {
            try
            {
                _alumnoService.CrearAlumno(nuevoAlumno);
                return Ok(new
                {
                    mensaje = "Alumno creado exitosamente",
                    alumno = nuevoAlumno
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/alumnos/12345
        [HttpPut("{nroLegajo}")]
        public IActionResult ActualizarAlumno(int nroLegajo, [FromBody] Alumno alumnoActualizado)
        {
            try
            {
                _alumnoService.ActualizarAlumno(nroLegajo, alumnoActualizado);
                return Ok(new
                {
                    mensaje = $"Alumno con legajo {nroLegajo} actualizado exitosamente",
                    alumno = alumnoActualizado
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/alumnos/12345
        [HttpDelete("{nroLegajo}")]
        public IActionResult EliminarAlumno(int nroLegajo)
        {
            try
            {
                _alumnoService.EliminarAlumno(nroLegajo);
                return Ok(new
                {
                    mensaje = $"Alumno con legajo {nroLegajo} eliminado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}