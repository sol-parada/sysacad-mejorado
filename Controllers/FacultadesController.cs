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

        public FacultadesController()
        {
            _facultadService = new FacultadService();
        }

        // GET: api/facultades
        [HttpGet]
        public IActionResult GetFacultades()
        {
            var facultades = _facultadService.ObtenerTodas();
            return Ok(facultades);
        }

        // GET: api/facultades/utn-frsr
        [HttpGet("{sigla}")]
        public IActionResult GetFacultad(string sigla)
        {
            try
            {
                var facultad = _facultadService.ObtenerPorSigla(sigla);
                if (facultad == null)
                    return NotFound();

                return Ok(facultad);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: api/facultades
        [HttpPost]
        public IActionResult CrearFacultad([FromBody] Facultad nuevaFacultad)
        {
            try
            {
                _facultadService.CrearFacultad(nuevaFacultad);
                return Ok(new
                {
                    mensaje = "Facultad creada exitosamente",
                    facultad = nuevaFacultad
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/facultades/utn-frsr
        [HttpPut("{sigla}")]
        public IActionResult ActualizarFacultad(string sigla, [FromBody] Facultad facultadActualizada)
        {
            try
            {
                _facultadService.ActualizarFacultad(sigla, facultadActualizada);
                return Ok(new
                {
                    mensaje = $"Facultad {sigla} actualizada exitosamente",
                    facultad = facultadActualizada
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/facultades/utn-frsr
        [HttpDelete("{sigla}")]
        public IActionResult EliminarFacultad(string sigla)
        {
            try
            {
                _facultadService.EliminarFacultad(sigla);
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