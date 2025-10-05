using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoridadesController : ControllerBase
    {
        private static List<Autoridad> _autoridades = new List<Autoridad>
        {
            new Autoridad
            {
                Nombre = "Ing. Juan Pérez",
                Cargo = "Decano",
                Telefono = "0260-7654321",
                Email = "decano@frut.utn.edu.ar"
            }
        };

        // GET: api/autoridades
        [HttpGet]
        public IActionResult GetAutoridades()
        {
            return Ok(_autoridades);
        }

        // POST: api/autoridades
        [HttpPost]
        public IActionResult CrearAutoridad([FromBody] Autoridad nuevaAutoridad)
        {
            _autoridades.Add(nuevaAutoridad);
            return Ok(new { mensaje = "Autoridad creada exitosamente", autoridad = nuevaAutoridad });
        }
        // PUT: api/autoridades/1
        [HttpPut("{id}")]
        public IActionResult ActualizarAutoridad(int id, [FromBody] Autoridad autoridadActualizada)
        {
            return Ok(new
            {
                mensaje = $"Autoridad con ID {id} actualizada exitosamente",
                autoridad = autoridadActualizada
            });
        }

        // DELETE: api/autoridades/1
        [HttpDelete("{id}")]
        public IActionResult EliminarAutoridad(int id)
        {
            return Ok(new
            {
                mensaje = $"Autoridad con ID {id} eliminada exitosamente"
            });
        }
    }
}