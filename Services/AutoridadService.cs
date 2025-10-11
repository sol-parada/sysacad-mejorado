using System;
using System.Collections.Generic;
using System.Linq;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class AutoridadService
    {
        private static readonly List<Autoridad> _autoridades = new List<Autoridad>
        {
            new Autoridad
            {
                Nombre = "Ing. Juan Pérez",
                Cargo = "Decano",
                Telefono = "0260-7654321",
                Email = "decano@frut.utn.edu.ar"
            },
            new Autoridad
            {
                Nombre = "Lic. María González",
                Cargo = "Secretaria Académica",
                Telefono = "0260-7654322",
                Email = "academica@frut.utn.edu.ar"
            }
        };

        private int _siguienteId = 3;

        // GET: Todas las autoridades
        public List<Autoridad> ObtenerTodas()
        {
            return _autoridades;
        }

        // GET: Autoridad por ID
        public Autoridad? ObtenerPorId(int id)
        {
            return _autoridades.FirstOrDefault(a => GetId(a) == id);
        }

        // POST: Crear autoridad
        public void CrearAutoridad(Autoridad autoridad)
        {
            // Validación: Nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(autoridad.Nombre))
            {
                throw new Exception("El nombre de la autoridad no puede estar vacío");
            }

            // Validación: Cargo no puede estar vacío
            if (string.IsNullOrWhiteSpace(autoridad.Cargo))
            {
                throw new Exception("El cargo de la autoridad no puede estar vacío");
            }

            // Validación: Email debe tener formato válido (opcional)
            if (!string.IsNullOrWhiteSpace(autoridad.Email) && !autoridad.Email.Contains("@"))
            {
                throw new Exception("El email de la autoridad debe tener un formato válido");
            }

            // Asignar ID automático
            SetId(autoridad, _siguienteId++);
            _autoridades.Add(autoridad);
        }

        // PUT: Actualizar autoridad
        public void ActualizarAutoridad(int id, Autoridad autoridadActualizada)
        {
            var autoridadExistente = ObtenerPorId(id);
            if (autoridadExistente == null)
            {
                throw new Exception($"No se encontró autoridad con ID {id}");
            }

            // Validación: Nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(autoridadActualizada.Nombre))
            {
                throw new Exception("El nombre de la autoridad no puede estar vacío");
            }

            // Validación: Cargo no puede estar vacío
            if (string.IsNullOrWhiteSpace(autoridadActualizada.Cargo))
            {
                throw new Exception("El cargo de la autoridad no puede estar vacío");
            }

            // Actualizar propiedades
            autoridadExistente.Nombre = autoridadActualizada.Nombre;
            autoridadExistente.Cargo = autoridadActualizada.Cargo;
            autoridadExistente.Telefono = autoridadActualizada.Telefono;
            autoridadExistente.Email = autoridadActualizada.Email;
        }

        // DELETE: Eliminar autoridad
        public void EliminarAutoridad(int id)
        {
            var autoridad = ObtenerPorId(id);
            if (autoridad == null)
            {
                throw new Exception($"No se encontró autoridad con ID {id}");
            }

            _autoridades.Remove(autoridad);
        }

        // Métodos auxiliares para manejar IDs (simulación de base de datos)
        private int GetId(Autoridad autoridad)
        {
            // Simulamos un ID basado en el índice + 1
            return _autoridades.IndexOf(autoridad) + 1;
        }

        private void SetId(Autoridad autoridad, int id)
        {
            // En una implementación real, esto lo manejaría la base de datos
            // Por ahora es solo para mantener la consistencia
        }
    }
}