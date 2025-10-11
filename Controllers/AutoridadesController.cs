using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;
using SysAcadMejorado.Services;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoridadesController : ControllerBase
    {
        private readonly AutoridadService _autoridadService;

        public AutoridadesController()
        {
            _autoridadService = new AutoridadService();
        }

        // GET: api/autoridades
        [HttpGet]
        public IActionResult GetAutoridades()
        {
            var autoridades = _autoridadService.ObtenerTodas();
            return Ok(autoridades);
        }

        // GET: api/autoridades/1
        [HttpGet("{id}")]
        public IActionResult GetAutoridad(int id)
        {
            try
            {
                var autoridad = _autoridadService.ObtenerPorId(id);
                if (autoridad == null)
                    return NotFound();

                return Ok(autoridad);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: api/autoridades
        [HttpPost]
        public IActionResult CrearAutoridad([FromBody] Autoridad nuevaAutoridad)
        {
            try
            {
                _autoridadService.CrearAutoridad(nuevaAutoridad);
                return Ok(new
                {
                    mensaje = "Autoridad creada exitosamente",
                    autoridad = nuevaAutoridad
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/autoridades/1
        [HttpPut("{id}")]
        public IActionResult ActualizarAutoridad(int id, [FromBody] Autoridad autoridadActualizada)
        {
            try
            {
                _autoridadService.ActualizarAutoridad(id, autoridadActualizada);
                return Ok(new
                {
                    mensaje = $"Autoridad con ID {id} actualizada exitosamente",
                    autoridad = autoridadActualizada
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/autoridades/1
        [HttpDelete("{id}")]
        public IActionResult EliminarAutoridad(int id)
        {
            try
            {
                _autoridadService.EliminarAutoridad(id);
                return Ok(new
                {
                    mensaje = $"Autoridad con ID {id} eliminada exitosamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}