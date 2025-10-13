using System;
using System.Collections.Generic;
using System.Linq;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class UniversidadService
    {
        private readonly List<Universidad> _universidades;

        public UniversidadService()
        {
            _universidades = new List<Universidad>
            {
                new Universidad {
                    Nombre = "Universidad Tecnológica Nacional",
                    Sigla = "UTN"
                },
                new Universidad {
                    Nombre = "Universidad de Buenos Aires",
                    Sigla = "UBA"
                }
            };
        }

        // GET: Todas las universidades
        public List<Universidad> ObtenerTodas()
        {
            return _universidades;
        }

        // GET: Universidad por sigla
        public Universidad? ObtenerPorSigla(string sigla)
        {
            return _universidades.FirstOrDefault(u =>
                u.Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase));
        }

        // POST: Crear universidad
        public void CrearUniversidad(Universidad universidad)
        {
            if (string.IsNullOrWhiteSpace(universidad.Sigla))
                throw new Exception("La sigla de la universidad no puede estar vacía");

            if (string.IsNullOrWhiteSpace(universidad.Nombre))
                throw new Exception("El nombre de la universidad no puede estar vacío");

            if (ObtenerPorSigla(universidad.Sigla) != null)
                throw new Exception($"Ya existe una universidad con la sigla {universidad.Sigla}");

            _universidades.Add(universidad);
        }

        // PUT: Actualizar universidad
        public void ActualizarUniversidad(string sigla, Universidad universidadActualizada)
        {
            var universidadExistente = ObtenerPorSigla(sigla);
            if (universidadExistente == null)
                throw new Exception($"No se encontró universidad con sigla {sigla}");

            if (string.IsNullOrWhiteSpace(universidadActualizada.Nombre))
                throw new Exception("El nombre de la universidad no puede estar vacío");

            universidadExistente.Nombre = universidadActualizada.Nombre;
            // Nota: No actualizamos la sigla porque es el identificador
        }

        // DELETE: Eliminar universidad
        public void EliminarUniversidad(string sigla)
        {
            var universidad = ObtenerPorSigla(sigla);
            if (universidad == null)
                throw new Exception($"No se encontró universidad con sigla {sigla}");

            _universidades.Remove(universidad);
        }
    }
}