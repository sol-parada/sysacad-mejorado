using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;
using SysAcadMejorado.Services;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultadesController : ControllerBase
    {
        private readonly FacultadService _facultadService;

        // ¡CAMBIO! Usar inyección de dependencias
        public FacultadesController(FacultadService facultadService)
        {
            _facultadService = facultadService;
        }

        // GET: api/facultades
        [HttpGet]
        public async Task<ActionResult<List<Facultad>>> GetFacultades()
        {
            try
            {
                var facultades = await _facultadService.ObtenerTodas();
                return Ok(facultades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // GET: api/facultades/utn-frsr
        [HttpGet("{sigla}")]
        public async Task<ActionResult<Facultad>> GetFacultad(string sigla)
        {
            try
            {
                var facultad = await _facultadService.ObtenerPorSigla(sigla);
                if (facultad == null)
                    return NotFound(new { error = $"No se encontró facultad con sigla {sigla}" });

                return Ok(facultad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // POST: api/facultades
        [HttpPost]
        public async Task<ActionResult<Facultad>> CrearFacultad([FromBody] Facultad nuevaFacultad)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { error = "Datos de la facultad inválidos" });

                var facultadCreada = await _facultadService.CrearFacultad(nuevaFacultad);

                return CreatedAtAction(
                    nameof(GetFacultad),
                    new { sigla = facultadCreada.Sigla },
                    new
                    {
                        mensaje = "Facultad creada exitosamente",
                        facultad = facultadCreada
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/facultades/utn-frsr
        [HttpPut("{sigla}")]
        public async Task<ActionResult<Facultad>> ActualizarFacultad(string sigla, [FromBody] Facultad facultadActualizada)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { error = "Datos de la facultad inválidos" });

                var facultadActualizadaResult = await _facultadService.ActualizarFacultad(sigla, facultadActualizada);

                return Ok(new
                {
                    mensaje = $"Facultad {sigla} actualizada exitosamente",
                    facultad = facultadActualizadaResult
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/facultades/utn-frsr
        [HttpDelete("{sigla}")]
        public async Task<ActionResult> EliminarFacultad(string sigla)
        {
            try
            {
                await _facultadService.EliminarFacultad(sigla);
                return Ok(new
                {
                    mensaje = $"Facultad {sigla} eliminada exitosamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}