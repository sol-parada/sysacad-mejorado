using System;
using System.Collections.Generic;
using System.Linq;
using SysAcadMejorado.Models;

namespace SysAcadMejorado.Services
{
    public class FacultadService
    {
        private static readonly List<Facultad> _facultades = new List<Facultad>
        {
            new Facultad
            {
                Nombre = "Facultad Regional San Rafael",
                Abreviatura = "FRSR",
                Directorio = "directorio_frsr",
                Sigla = "UTN-FRSR",
                CodigoPostal = "5600",
                Ciudad = "San Rafael",
                Domicilio = "Calle Ejemplo 123",
                Telefono = "0260-1234567",
                Contacto = "Secretaría Académica",
                Email = "contacto@frut.utn.edu.ar"
            },
            new Facultad
            {
                Nombre = "Facultad Regional Mendoza",
                Abreviatura = "FRM",
                Directorio = "directorio_frm",
                Sigla = "UTN-FRM",
                CodigoPostal = "5500",
                Ciudad = "Mendoza",
                Domicilio = "Avenida Principal 456",
                Telefono = "0261-9876543",
                Contacto = "Informes",
                Email = "informes@frm.utn.edu.ar"
            }
        };

        // GET: Todas las facultades
        public List<Facultad> ObtenerTodas()
        {
            return _facultades;
        }

        // GET: Facultad por sigla
        public Facultad? ObtenerPorSigla(string sigla)
        {
            return _facultades.FirstOrDefault(f =>
                f.Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase));
        }

        // GET: Buscar facultades por ciudad
        public List<Facultad> BuscarPorCiudad(string ciudad)
        {
            return _facultades.Where(f =>
                f.Ciudad.Contains(ciudad, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // POST: Crear facultad
        public void CrearFacultad(Facultad facultad)
        {
            // Validación: Sigla no puede estar vacía
            if (string.IsNullOrWhiteSpace(facultad.Sigla))
            {
                throw new Exception("La sigla de la facultad no puede estar vacía");
            }

            // Validación: Nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(facultad.Nombre))
            {
                throw new Exception("El nombre de la facultad no puede estar vacío");
            }

            // Validación: Ciudad no puede estar vacía
            if (string.IsNullOrWhiteSpace(facultad.Ciudad))
            {
                throw new Exception("La ciudad de la facultad no puede estar vacía");
            }

            // Validación: Sigla debe ser única
            if (ObtenerPorSigla(facultad.Sigla) != null)
            {
                throw new Exception($"Ya existe una facultad con la sigla {facultad.Sigla}");
            }

            // Validación: Email debe tener formato válido (si se proporciona)
            if (!string.IsNullOrWhiteSpace(facultad.Email) && !facultad.Email.Contains("@"))
            {
                throw new Exception("El email de la facultad debe tener un formato válido");
            }

            // Validación: Abreviatura no puede estar vacía
            if (string.IsNullOrWhiteSpace(facultad.Abreviatura))
            {
                throw new Exception("La abreviatura de la facultad no puede estar vacía");
            }

            _facultades.Add(facultad);
        }

        // PUT: Actualizar facultad
        public void ActualizarFacultad(string sigla, Facultad facultadActualizada)
        {
            var facultadExistente = ObtenerPorSigla(sigla);
            if (facultadExistente == null)
            {
                throw new Exception($"No se encontró facultad con sigla {sigla}");
            }

            // Validación: Nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(facultadActualizada.Nombre))
            {
                throw new Exception("El nombre de la facultad no puede estar vacío");
            }

            // Validación: Ciudad no puede estar vacía
            if (string.IsNullOrWhiteSpace(facultadActualizada.Ciudad))
            {
                throw new Exception("La ciudad de la facultad no puede estar vacía");
            }

            // Validación: Si cambia la sigla, debe ser única
            if (!facultadActualizada.Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase) &&
                ObtenerPorSigla(facultadActualizada.Sigla) != null)
            {
                throw new Exception($"Ya existe una facultad con la sigla {facultadActualizada.Sigla}");
            }

            // Validación: Abreviatura no puede estar vacía
            if (string.IsNullOrWhiteSpace(facultadActualizada.Abreviatura))
            {
                throw new Exception("La abreviatura de la facultad no puede estar vacía");
            }

            // Actualizar propiedades
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
        }

        // DELETE: Eliminar facultad
        public void EliminarFacultad(string sigla)
        {
            var facultad = ObtenerPorSigla(sigla);
            if (facultad == null)
            {
                throw new Exception($"No se encontró facultad con sigla {sigla}");
            }

            _facultades.Remove(facultad);
        }

        // GET: Obtener facultades por universidad (basado en sigla)
        public List<Facultad> ObtenerPorUniversidad(string siglaUniversidad)
        {
            return _facultades.Where(f =>
                f.Sigla.StartsWith(siglaUniversidad, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}