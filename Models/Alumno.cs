using SysAcadMejorado.Models;
using System;
namespace SysacadMejorado.Models
{
    public class Alumno
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string NroDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public int NroLegajo { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}