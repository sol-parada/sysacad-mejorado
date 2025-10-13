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

        // ¡CAMBIO! Usar inyección de dependencias
        public MateriasController(MateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        // GET: api/materias
        [HttpGet]
        public async Task<ActionResult<List<Materia>>> GetMaterias()
        {
            try
            {
                var materias = await _materiaService.ObtenerTodas();
                return Ok(materias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // GET: api/materias/prog1
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Materia>> GetMateria(string codigo)
        {
            try
            {
                var materia = await _materiaService.ObtenerPorCodigo(codigo);
                if (materia == null)
                    return NotFound(new { error = $"No se encontró materia con código {codigo}" });

                return Ok(materia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor: " + ex.Message });
            }
        }

        // POST: api/materias
        [HttpPost]
        public async Task<ActionResult<Materia>> CrearMateria([FromBody] Materia nuevaMateria)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { error = "Datos de la materia inválidos" });

                var materiaCreada = await _materiaService.CrearMateria(nuevaMateria);

                return CreatedAtAction(
                    nameof(GetMateria),
                    new { codigo = materiaCreada.Codigo },
                    new
                    {
                        mensaje = "Materia creada exitosamente",
                        materia = materiaCreada
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/materias/prog1
        [HttpPut("{codigo}")]
        public async Task<ActionResult<Materia>> ActualizarMateria(string codigo, [FromBody] Materia materiaActualizada)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { error = "Datos de la materia inválidos" });

                var materiaActualizadaResult = await _materiaService.ActualizarMateria(codigo, materiaActualizada);

                return Ok(new
                {
                    mensaje = $"Materia {codigo} actualizada exitosamente",
                    materia = materiaActualizadaResult
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/materias/prog1
        [HttpDelete("{codigo}")]
        public async Task<ActionResult> EliminarMateria(string codigo)
        {
            try
            {
                await _materiaService.EliminarMateria(codigo);
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