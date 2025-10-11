using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;
using SysAcadMejorado.Services;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversidadesController : ControllerBase
    {
        private readonly UniversidadService _universidadService;

        public UniversidadesController()
        {
            _universidadService = new UniversidadService();
        }

        // GET: api/universidades
        [HttpGet]
        public IActionResult GetUniversidades()
        {
            var universidades = _universidadService.ObtenerTodas();
            return Ok(universidades);
        }

        // GET: api/universidades/utn
        [HttpGet("{sigla}")]
        public IActionResult GetUniversidad(string sigla)
        {
            try
            {
                var universidad = _universidadService.ObtenerPorSigla(sigla);
                if (universidad == null)
                    return NotFound();

                return Ok(universidad);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: api/universidades
        [HttpPost]
        public IActionResult CrearUniversidad([FromBody] Universidad nuevaUniversidad)
        {
            try
            {
                _universidadService.CrearUniversidad(nuevaUniversidad);
                return Ok(new
                {
                    mensaje = "Universidad creada exitosamente",
                    universidad = nuevaUniversidad
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/universidades/utn
        [HttpPut("{sigla}")]
        public IActionResult ActualizarUniversidad(string sigla, [FromBody] Universidad universidadActualizada)
        {
            try
            {
                _universidadService.ActualizarUniversidad(sigla, universidadActualizada);
                return Ok(new
                {
                    mensaje = $"Universidad {sigla} actualizada exitosamente",
                    universidad = universidadActualizada
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/universidades/utn
        [HttpDelete("{sigla}")]
        public IActionResult EliminarUniversidad(string sigla)
        {
            try
            {
                _universidadService.EliminarUniversidad(sigla);
                return Ok(new
                {
                    mensaje = $"Universidad {sigla} eliminada exitosamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}