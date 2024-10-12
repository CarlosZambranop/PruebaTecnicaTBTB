using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaTbTb.Models
{
    public class Medico
    {
        public int MedicoID { get; set; } // Clave primaria

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(50, ErrorMessage = "La especialidad no puede exceder los 50 caracteres.")]
        public string Especialidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; } // Fecha de ingreso al hospital

        // Navegación para citas
        public virtual ICollection<CitaMedica> CitasMedicas { get; set; }
    }
}
