using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class MateriaService
    {
        private readonly AppDbContext _context;

        public MateriaService(AppDbContext context)
        {
            _context = context;
        }

        // GET: Todas las materias
        public async Task<List<Materia>> ObtenerTodas()
        {
            return await _context.Materias.ToListAsync();
        }

        // GET: Materia por código - ✅ ARREGLADO para PostgreSQL
        public async Task<Materia?> ObtenerPorCodigo(string codigo)
        {
            return await _context.Materias
                .Where(m => m.Codigo.ToLower() == codigo.ToLower())
                .FirstOrDefaultAsync();
        }

        // GET: Buscar materias por nombre - ✅ ARREGLADO para PostgreSQL  
        public async Task<List<Materia>> BuscarPorNombre(string texto)
        {
            return await _context.Materias
                .Where(m => m.Nombre.ToLower().Contains(texto.ToLower()))
                .ToListAsync();
        }

        // POST: Crear materia
        public async Task<Materia> CrearMateria(Materia materia)
        {
            if (string.IsNullOrWhiteSpace(materia.Codigo))
                throw new Exception("El código de la materia no puede estar vacío");

            if (string.IsNullOrWhiteSpace(materia.Nombre))
                throw new Exception("El nombre de la materia no puede estar vacío");

            var materiaExistente = await ObtenerPorCodigo(materia.Codigo);
            if (materiaExistente != null)
                throw new Exception($"Ya existe una materia con el código {materia.Codigo}");

            if (!EsCodigoValido(materia.Codigo))
                throw new Exception("El código de la materia debe contener solo letras y números");

            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();

            return materia;
        }

        // PUT: Actualizar materia
        public async Task<Materia> ActualizarMateria(string codigo, Materia materiaActualizada)
        {
            var materiaExistente = await ObtenerPorCodigo(codigo);
            if (materiaExistente == null)
                throw new Exception($"No se encontró materia con código {codigo}");

            if (string.IsNullOrWhiteSpace(materiaActualizada.Nombre))
                throw new Exception("El nombre de la materia no puede estar vacío");

            // ✅ ARREGLADO: Comparación compatible con PostgreSQL
            if (!materiaActualizada.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                var otraMateria = await ObtenerPorCodigo(materiaActualizada.Codigo);
                if (otraMateria != null)
                    throw new Exception($"Ya existe una materia con el código {materiaActualizada.Codigo}");
            }

            if (!EsCodigoValido(materiaActualizada.Codigo))
                throw new Exception("El código de la materia debe contener solo letras y números");

            materiaExistente.Nombre = materiaActualizada.Nombre;
            materiaExistente.Codigo = materiaActualizada.Codigo;
            materiaExistente.Observacion = materiaActualizada.Observacion;

            await _context.SaveChangesAsync();
            return materiaExistente;
        }

        // DELETE: Eliminar materia
        public async Task EliminarMateria(string codigo)
        {
            var materia = await ObtenerPorCodigo(codigo);
            if (materia == null)
                throw new Exception($"No se encontró materia con código {codigo}");

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
        }

        // Método auxiliar para validar formato de código
        private bool EsCodigoValido(string codigo)
        {
            return !string.IsNullOrWhiteSpace(codigo) &&
                   codigo.All(c => char.IsLetterOrDigit(c));
        }
        // 🔥 MÉTODOS SÍNCRONOS PARA UNIT TESTS
        public List<Materia> ObtenerTodasSync()
        {
            return _context.Materias.ToList();
        }

        public Materia? ObtenerPorCodigoSync(string codigo)
        {
            return _context.Materias
                .Where(m => m.Codigo.ToLower() == codigo.ToLower())
                .FirstOrDefault();
        }

        public Materia CrearMateriaSync(Materia materia)
        {
            if (string.IsNullOrWhiteSpace(materia.Codigo))
                throw new Exception("El código de la materia no puede estar vacío");

            if (string.IsNullOrWhiteSpace(materia.Nombre))
                throw new Exception("El nombre de la materia no puede estar vacío");

            var materiaExistente = ObtenerPorCodigoSync(materia.Codigo);
            if (materiaExistente != null)
                throw new Exception($"Ya existe una materia con el código {materia.Codigo}");

            if (!EsCodigoValido(materia.Codigo))
                throw new Exception("El código de la materia debe contener solo letras y números");

            _context.Materias.Add(materia);
            _context.SaveChanges();

            return materia;

        }
    }
}