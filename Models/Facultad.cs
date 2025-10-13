using Microsoft.Extensions.Diagnostics.HealthChecks;
using SysAcadMejorado.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SysAcadMejorado.Models
{
    public class Facultad
    {
        [Key]  // CLAVE PRIMARIA
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Abreviatura { get; set; }
        public string? Directorio { get; set; }
        public string? Sigla { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Ciudad { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Contacto { get; set; }
        public string? Email { get; set; }
    }
}
