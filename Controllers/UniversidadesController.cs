using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversidadesController : ControllerBase
    {
        private static List<Universidad> _universidades = new List<Universidad>
        {
            new Universidad { Nombre = "Universidad Tecnológica Nacional", Sigla = "UTN" }
        };

        // GET: api/universidades
        [HttpGet]
        public IActionResult GetUniversidades()
        {
            return Ok(_universidades);
        }

        // GET: api/universidades/utn
        [HttpGet("{sigla}")]
        public IActionResult GetUniversidad(string sigla)
        {
            var universidad = _universidades.FirstOrDefault(u => u.Sigla == sigla);
            if (universidad == null)
                return NotFound();

            return Ok(universidad);
        }

        // POST: api/universidades
        [HttpPost]
        public IActionResult CrearUniversidad([FromBody] Universidad nuevaUniversidad)
        {
            _universidades.Add(nuevaUniversidad);
            return Ok(new { mensaje = "Universidad creada exitosamente", universidad = nuevaUniversidad });
        }
        // PUT: api/universidades/utn
        [HttpPut("{sigla}")]
        public IActionResult ActualizarUniversidad(string sigla, [FromBody] Universidad universidadActualizada)
        {
            return Ok(new
            {
                mensaje = $"Universidad {sigla} actualizada exitosamente",
                universidad = universidadActualizada
            });
        }

        // DELETE: api/universidades/utn  
        [HttpDelete("{sigla}")]
        public IActionResult EliminarUniversidad(string sigla)
        {
            return Ok(new
            {
                mensaje = $"Universidad {sigla} eliminada exitosamente"
            });
        }
    }
}