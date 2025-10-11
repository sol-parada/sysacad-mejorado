using SysacadMejorado.Models;
using SysAcadMejorado.Models;
using System.Xml.Linq;

namespace SysAcadMejorado.Services
{
    public class AlumnoService
    {
        private readonly List<Alumno> _alumnos = new List<Alumno>
        {
            new Alumno
            {
                Apellido = "García",
                Nombre = "Ana",
                NroDocumento = "40123456",
                TipoDocumento = TipoDocumento.DNI,
                FechaNacimiento = new DateTime(2000, 5, 15),
                Sexo = "Femenino",
                NroLegajo = 12345,
                FechaIngreso = new DateTime(2023, 3, 1)
            }
        };

        // GET: Todos los alumnos
        public List<Alumno> ObtenerTodos()
        {
            return _alumnos;
        }

        // GET: Alumno por legajo
        public Alumno? ObtenerPorLegajo(int legajo)
        {
            return _alumnos.FirstOrDefault(a => a.NroLegajo == legajo);
        }

        // POST: Crear alumno
        public void CrearAlumno(Alumno alumno)
        {
            // VALIDACIÓN: No puede existir otro con mismo legajo
            if (ObtenerPorLegajo(alumno.NroLegajo) != null)
            {
                throw new Exception($"Ya existe un alumno con el legajo {alumno.NroLegajo}");
            }

            // VALIDACIÓN: Debe ser mayor de 16 años
            if (DateTime.Now.Year - alumno.FechaNacimiento.Year < 16)
            {
                throw new Exception("El alumno debe tener al menos 16 años");
            }

            _alumnos.Add(alumno);
        }

        // PUT: Actualizar alumno
        public void ActualizarAlumno(int legajo, Alumno alumnoActualizado)
        {
            var alumnoExistente = ObtenerPorLegajo(legajo);
            if (alumnoExistente == null)
            {
                throw new Exception($"No se encontró alumno con legajo {legajo}");
            }

            // Actualizar propiedades
            alumnoExistente.Apellido = alumnoActualizado.Apellido;
            alumnoExistente.Nombre = alumnoActualizado.Nombre;
            alumnoExistente.NroDocumento = alumnoActualizado.NroDocumento;
            // ... más propiedades
        }

        // DELETE: Eliminar alumno
        public void EliminarAlumno(int legajo)
        {
            var alumno = ObtenerPorLegajo(legajo);
            if (alumno == null)
            {
                throw new Exception($"No se encontró alumno con legajo {legajo}");
            }

            _alumnos.Remove(alumno);
        }
    }
}