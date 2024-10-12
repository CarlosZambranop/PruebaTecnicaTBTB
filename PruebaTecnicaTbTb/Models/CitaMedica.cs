using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaTbTb.Models
{
    //genero el modelos de muchos muchos 
    public class CitaMedica
    {
        [Key]
        public int CitaID { get; set; }

        [Required]
        public int PacienteID { get; set; }

        [Required]
        public int MedicoID { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }

        [Required]
        [StringLength(255)]
        public string MotivoConsulta { get; set; }

        [ForeignKey("PacienteID")]
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("MedicoID")]
        public virtual Medico Medico { get; set; }
    }
}
