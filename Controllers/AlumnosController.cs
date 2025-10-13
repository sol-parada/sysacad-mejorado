using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;
using SysAcadMejorado.Models;
using SysAcadMejorado.Services;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnoService _alumnoService;

        // INYECCIÓN DE DEPENDENCIAS - Ya no usa new()
        public AlumnosController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        // GET: api/alumnos
        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumnos()
        {
            try
            {
                var alumnos = await _alumnoService.ObtenerTodos();
                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // GET: api/alumnos/legajo/12345
        [HttpGet("legajo/{nroLegajo}")]
        public async Task<ActionResult<Alumno>> GetAlumnoPorLegajo(int nroLegajo)
        {
            try
            {
                var alumno = await _alumnoService.ObtenerPorLegajo(nroLegajo);
                if (alumno == null)
                    return NotFound(new { error = $"No se encontró alumno con legajo {nroLegajo}" });

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // GET: api/alumnos/5 (por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumnoPorId(int id)
        {
            try
            {
                var alumno = await _alumnoService.ObtenerPorId(id);
                if (alumno == null)
                    return NotFound(new { error = $"No se encontró alumno con ID {id}" });

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // POST: api/alumnos
        [HttpPost]
        public async Task<ActionResult<Alumno>> CrearAlumno([FromBody] Alumno nuevoAlumno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { error = "Datos del alumno inválidos" });

                var alumnoCreado = await _alumnoService.CrearAlumno(nuevoAlumno);

                return CreatedAtAction(
                    nameof(GetAlumnoPorId),
                    new { id = alumnoCreado.Id },
                    new
                    {
                        mensaje = "Alumno creado exitosamente",
                        alumno = alumnoCreado
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/alumnos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Alumno>> ActualizarAlumno(int id, [FromBody] Alumno alumnoActualizado)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { error = "Datos del alumno inválidos" });

                var alumnoActualizadoResult = await _alumnoService.ActualizarAlumno(id, alumnoActualizado);

                return Ok(new
                {
                    mensaje = $"Alumno con ID {id} actualizado exitosamente",
                    alumno = alumnoActualizadoResult
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/alumnos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAlumno(int id)
        {
            try
            {
                await _alumnoService.EliminarAlumno(id);
                return Ok(new
                {
                    mensaje = $"Alumno con ID {id} eliminado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}