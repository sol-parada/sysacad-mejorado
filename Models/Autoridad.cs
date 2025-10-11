using SysAcadMejorado.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SysAcadMejorado.Models
{
    public class Autoridad
    {
        [Key]  // CLAVE PRIMARIA
        public int Id { get; set; }
        public string? Nombre {get; set; }
        public string? Cargo { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
