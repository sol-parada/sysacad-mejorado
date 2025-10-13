using SysAcadMejorado.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SysAcadMejorado.Models
{
    public class Cargo
    {
        [Key]  // CLAVE PRIMARIA
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Puntos { get; set; }
    }
}
