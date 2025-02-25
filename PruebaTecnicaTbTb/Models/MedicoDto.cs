﻿using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaTbTb.Models
{
    //Dto para evitar datos inecesarios en la creacion
    public class MedicoDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; }

        public DateTime? FechaIngreso { get; set; }
    }
}
