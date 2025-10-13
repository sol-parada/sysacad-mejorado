using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class FacultadService
    {
        private readonly AppDbContext _context;

        public FacultadService(AppDbContext context)
        {
            _context = context;
        }

        // GET: Todas las facultades
        public async Task<List<Facultad>> ObtenerTodas()
        {
            return await _context.Facultades.ToListAsync();
        }

        // GET: Facultad por sigla - ✅ ARREGLADO para PostgreSQL
        public async Task<Facultad?> ObtenerPorSigla(string sigla)
        {
            return await _context.Facultades
                .Where(f => f.Sigla.ToLower() == sigla.ToLower())
                .FirstOrDefaultAsync();
        }

        // GET: Buscar facultades por ciudad - ✅ ARREGLADO para PostgreSQL
        public async Task<List<Facultad>> BuscarPorCiudad(string ciudad)
        {
            return await _context.Facultades
                .Where(f => f.Ciudad.ToLower().Contains(ciudad.ToLower()))
                .ToListAsync();
        }

        // POST: Crear facultad
        public async Task<Facultad> CrearFacultad(Facultad facultad)
        {
            if (string.IsNullOrWhiteSpace(facultad.Sigla))
                throw new Exception("La sigla de la facultad no puede estar vacía");

            if (string.IsNullOrWhiteSpace(facultad.Nombre))
                throw new Exception("El nombre de la facultad no puede estar vacío");

            if (string.IsNullOrWhiteSpace(facultad.Abreviatura))
                throw new Exception("La abreviatura de la facultad no puede estar vacía");

            if (string.IsNullOrWhiteSpace(facultad.Ciudad))
                throw new Exception("La ciudad de la facultad no puede estar vacía");

            var facultadExistente = await ObtenerPorSigla(facultad.Sigla);
            if (facultadExistente != null)
                throw new Exception($"Ya existe una facultad con la sigla {facultad.Sigla}");

            if (!string.IsNullOrWhiteSpace(facultad.Email) && !facultad.Email.Contains("@"))
                throw new Exception("El email de la facultad debe tener un formato válido");

            _context.Facultades.Add(facultad);
            await _context.SaveChangesAsync();

            return facultad;
        }

        // PUT: Actualizar facultad
        public async Task<Facultad> ActualizarFacultad(string sigla, Facultad facultadActualizada)
        {
            var facultadExistente = await ObtenerPorSigla(sigla);
            if (facultadExistente == null)
                throw new Exception($"No se encontró facultad con sigla {sigla}");

            if (string.IsNullOrWhiteSpace(facultadActualizada.Nombre))
                throw new Exception("El nombre de la facultad no puede estar vacío");

            if (string.IsNullOrWhiteSpace(facultadActualizada.Abreviatura))
                throw new Exception("La abreviatura de la facultad no puede estar vacía");

            if (string.IsNullOrWhiteSpace(facultadActualizada.Ciudad))
                throw new Exception("La ciudad de la facultad no puede estar vacía");

            // ✅ ARREGLADO: Comparación compatible con PostgreSQL
            if (!facultadActualizada.Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase))
            {
                var otraFacultad = await ObtenerPorSigla(facultadActualizada.Sigla);
                if (otraFacultad != null)
                    throw new Exception($"Ya existe una facultad con la sigla {facultadActualizada.Sigla}");
            }

            facultadExistente.Nombre = facultadActualizada.Nombre;
            facultadExistente.Abreviatura = facultadActualizada.Abreviatura;
            facultadExistente.Directorio = facultadActualizada.Directorio;
            facultadExistente.Sigla = facultadActualizada.Sigla;
            facultadExistente.CodigoPostal = facultadActualizada.CodigoPostal;
            facultadExistente.Ciudad = facultadActualizada.Ciudad;
            facultadExistente.Domicilio = facultadActualizada.Domicilio;
            facultadExistente.Telefono = facultadActualizada.Telefono;
            facultadExistente.Contacto = facultadActualizada.Contacto;
            facultadExistente.Email = facultadActualizada.Email;

            await _context.SaveChangesAsync();
            return facultadExistente;
        }

        // DELETE: Eliminar facultad
        public async Task EliminarFacultad(string sigla)
        {
            var facultad = await ObtenerPorSigla(sigla);
            if (facultad == null)
                throw new Exception($"No se encontró facultad con sigla {sigla}");

            _context.Facultades.Remove(facultad);
            await _context.SaveChangesAsync();
        }

        // GET: Obtener facultades por universidad - ✅ ARREGLADO para PostgreSQL
        public async Task<List<Facultad>> ObtenerPorUniversidad(string siglaUniversidad)
        {
            return await _context.Facultades
                .Where(f => f.Sigla.ToLower().StartsWith(siglaUniversidad.ToLower()))
                .ToListAsync();
        }
    }
}