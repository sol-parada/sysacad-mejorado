using System;
using System.Collections.Generic;
using System.Linq;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class MateriaService
    {
        private static readonly List<Materia> _materias = new List<Materia>
        {
            new Materia
            {
                Nombre = "Programación I",
                Codigo = "PROG1",
                Observacion = "Materia inicial de programación"
            },
            new Materia
            {
                Nombre = "Base de Datos",
                Codigo = "BDD",
                Observacion = "Fundamentos de bases de datos"
            },
            new Materia
            {
                Nombre = "Sistemas Operativos",
                Codigo = "SO",
                Observacion = "Administración de sistemas operativos"
            }
        };

        // GET: Todas las materias
        public List<Materia> ObtenerTodas()
        {
            return _materias;
        }

        // GET: Materia por código
        public Materia? ObtenerPorCodigo(string codigo)
        {
            return _materias.FirstOrDefault(m =>
                m.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        // GET: Buscar materias por nombre
        public List<Materia> BuscarPorNombre(string texto)
        {
            return _materias.Where(m =>
                m.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // POST: Crear materia
        public void CrearMateria(Materia materia)
        {
            // Validación: Código no puede estar vacío
            if (string.IsNullOrWhiteSpace(materia.Codigo))
            {
                throw new Exception("El código de la materia no puede estar vacío");
            }

            // Validación: Nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(materia.Nombre))
            {
                throw new Exception("El nombre de la materia no puede estar vacío");
            }

            // Validación: Código debe ser único
            if (ObtenerPorCodigo(materia.Codigo) != null)
            {
                throw new Exception($"Ya existe una materia con el código {materia.Codigo}");
            }

            // Validación: Código debe tener formato válido (ej: LETRAS+NÚMEROS)
            if (!EsCodigoValido(materia.Codigo))
            {
                throw new Exception("El código de la materia debe contener solo letras y números");
            }

            _materias.Add(materia);
        }

        // PUT: Actualizar materia
        public void ActualizarMateria(string codigo, Materia materiaActualizada)
        {
            var materiaExistente = ObtenerPorCodigo(codigo);
            if (materiaExistente == null)
            {
                throw new Exception($"No se encontró materia con código {codigo}");
            }

            // Validación: Nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(materiaActualizada.Nombre))
            {
                throw new Exception("El nombre de la materia no puede estar vacío");
            }

            // Validación: Si cambia el código, debe ser único
            if (!materiaActualizada.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase) &&
                ObtenerPorCodigo(materiaActualizada.Codigo) != null)
            {
                throw new Exception($"Ya existe una materia con el código {materiaActualizada.Codigo}");
            }

            // Validación: Nuevo código debe ser válido
            if (!EsCodigoValido(materiaActualizada.Codigo))
            {
                throw new Exception("El código de la materia debe contener solo letras y números");
            }

            // Actualizar propiedades
            materiaExistente.Nombre = materiaActualizada.Nombre;
            materiaExistente.Codigo = materiaActualizada.Codigo;
            materiaExistente.Observacion = materiaActualizada.Observacion;
        }

        // DELETE: Eliminar materia
        public void EliminarMateria(string codigo)
        {
            var materia = ObtenerPorCodigo(codigo);
            if (materia == null)
            {
                throw new Exception($"No se encontró materia con código {codigo}");
            }

            _materias.Remove(materia);
        }

        // Método auxiliar para validar formato de código
        private bool EsCodigoValido(string codigo)
        {
            // El código debe contener solo letras y números, sin espacios
            return !string.IsNullOrWhiteSpace(codigo) &&
                   codigo.All(c => char.IsLetterOrDigit(c));
        }
    }
}