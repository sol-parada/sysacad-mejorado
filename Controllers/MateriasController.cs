using Microsoft.AspNetCore.Mvc;
using SysAcadMejorado.Models;
using SysAcadMejorado.Services;

namespace SysAcadMejorado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasController : ControllerBase
    {
        private readonly MateriaService _materiaService;

        public MateriasController()
        {
            _materiaService = new MateriaService();
        }

        // GET: api/materias
        [HttpGet]
        public IActionResult GetMaterias()
        {
            var materias = _materiaService.ObtenerTodas();
            return Ok(materias);
        }

        // GET: api/materias/prog1
        [HttpGet("{codigo}")]
        public IActionResult GetMateria(string codigo)
        {
            try
            {
                var materia = _materiaService.ObtenerPorCodigo(codigo);
                if (materia == null)
                    return NotFound();

                return Ok(materia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: api/materias
        [HttpPost]
        public IActionResult CrearMateria([FromBody] Materia nuevaMateria)
        {
            try
            {
                _materiaService.CrearMateria(nuevaMateria);
                return Ok(new
                {
                    mensaje = "Materia creada exitosamente",
                    materia = nuevaMateria
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/materias/prog1
        [HttpPut("{codigo}")]
        public IActionResult ActualizarMateria(string codigo, [FromBody] Materia materiaActualizada)
        {
            try
            {
                _materiaService.ActualizarMateria(codigo, materiaActualizada);
                return Ok(new
                {
                    mensaje = $"Materia {codigo} actualizada exitosamente",
                    materia = materiaActualizada
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/materias/prog1
        [HttpDelete("{codigo}")]
        public IActionResult EliminarMateria(string codigo)
        {
            try
            {
                _materiaService.EliminarMateria(codigo);
                return Ok(new
                {
                    mensaje = $"Materia {codigo} eliminada exitosamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}