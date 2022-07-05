using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Auditoria
    {
        [Key]
        public int  AuditoriaId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        [StringLength(150)]
        public String Descripcion { get; set; }
    }
}
