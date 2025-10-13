using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class AutoridadService
    {
        private readonly AppDbContext _context;

        public AutoridadService(AppDbContext context)
        {
            _context = context;
        }

        // GET: Todas las autoridades
        public List<Autoridad> ObtenerTodas()
        {
            return _context.Autoridades.ToList();
        }

        // GET: Autoridad por ID
        public Autoridad? ObtenerPorId(int id)
        {
            return _context.Autoridades.Find(id);
        }

        // POST: Crear autoridad
        public void CrearAutoridad(Autoridad autoridad)
        {
            if (string.IsNullOrWhiteSpace(autoridad.Nombre))
                throw new Exception("El nombre de la autoridad no puede estar vacío");

            if (string.IsNullOrWhiteSpace(autoridad.Cargo))
                throw new Exception("El cargo de la autoridad no puede estar vacío");

            if (!string.IsNullOrWhiteSpace(autoridad.Email) && !autoridad.Email.Contains("@"))
                throw new Exception("El email de la autoridad debe tener un formato válido");

            _context.Autoridades.Add(autoridad);
            _context.SaveChanges();
        }

        // PUT: Actualizar autoridad
        public void ActualizarAutoridad(int id, Autoridad autoridadActualizada)
        {
            var autoridadExistente = _context.Autoridades.Find(id);
            if (autoridadExistente == null)
                throw new Exception($"No se encontró autoridad con ID {id}");

            if (string.IsNullOrWhiteSpace(autoridadActualizada.Nombre))
                throw new Exception("El nombre de la autoridad no puede estar vacío");

            if (string.IsNullOrWhiteSpace(autoridadActualizada.Cargo))
                throw new Exception("El cargo de la autoridad no puede estar vacío");

            autoridadExistente.Nombre = autoridadActualizada.Nombre;
            autoridadExistente.Cargo = autoridadActualizada.Cargo;
            autoridadExistente.Telefono = autoridadActualizada.Telefono;
            autoridadExistente.Email = autoridadActualizada.Email;

            _context.SaveChanges();
        }

        // DELETE: Eliminar autoridad
        public void EliminarAutoridad(int id)
        {
            var autoridad = _context.Autoridades.Find(id);
            if (autoridad == null)
                throw new Exception($"No se encontró autoridad con ID {id}");

            _context.Autoridades.Remove(autoridad);
            _context.SaveChanges();
        }
    }
}