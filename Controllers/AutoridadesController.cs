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

        public AutoridadesController(AutoridadService autoridadService)
        {
            _autoridadService = autoridadService;
        }

        [HttpGet]
        public IActionResult GetAutoridades()
        {
            var autoridades = _autoridadService.ObtenerTodas();
            return Ok(autoridades);
        }

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

        [HttpPost]
        public IActionResult CrearAutoridad([FromBody] Autoridad nuevaAutoridad)
        {
            try
            {
                _autoridadService.CrearAutoridad(nuevaAutoridad);

                // Recupera la autoridad recién creada con el Id asignado
                var autoridadCreada = _autoridadService.ObtenerPorId(nuevaAutoridad.Id);

                return Ok(new
                {
                    mensaje = "Autoridad creada exitosamente",
                    autoridad = autoridadCreada
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

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
