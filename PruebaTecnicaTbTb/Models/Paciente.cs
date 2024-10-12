using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaTbTb.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteID { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int MedicoID { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; } = DateTime.Today;

        [ForeignKey("MedicoID")]
        public virtual Medico Medico { get; set; }
        public virtual ICollection<CitaMedica> CitasMedicas { get; set; }
    }
}
