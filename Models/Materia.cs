﻿using SysAcadMejorado.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SysAcadMejorado.Models
{
    public class Materia
    {
        [Key]  // CLAVE PRIMARIA
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Observacion { get; set; }
    }
}
