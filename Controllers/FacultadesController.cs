using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultadesController : ControllerBase
    {
        private static List<Facultad> _facultades = new List<Facultad>
        {
            new Facultad
            {
                Nombre = "Facultad Regional San Rafael",
                Abreviatura = "FRSR",
                Sigla = "UTN-FRSR",
                Ciudad = "San Rafael",
                Domicilio = "Calle Ejemplo 123",
                Telefono = "0260-1234567",
                Email = "contacto@frut.utn.edu.ar"
            }
        };

        // GET: api/facultades
        [HttpGet]
        public IActionResult GetFacultades()
        {
            return Ok(_facultades);
        }

        // POST: api/facultades
        [HttpPost]
        public IActionResult CrearFacultad([FromBody] Facultad nuevaFacultad)
        {
            _facultades.Add(nuevaFacultad);
            return Ok(new { mensaje = "Facultad creada exitosamente", facultad = nuevaFacultad });
        }
        // PUT: api/facultades/utn-frsr
        [HttpPut("{sigla}")]
        public IActionResult ActualizarFacultad(string sigla, [FromBody] Facultad facultadActualizada)
        {
            return Ok(new
            {
                mensaje = $"Facultad {sigla} actualizada exitosamente",
                facultad = facultadActualizada
            });
        }

        // DELETE: api/facultades/utn-frsr
        [HttpDelete("{sigla}")]
        public IActionResult EliminarFacultad(string sigla)
        {
            return Ok(new
            {
                mensaje = $"Facultad {sigla} eliminada exitosamente"
            });
        }
    }
}