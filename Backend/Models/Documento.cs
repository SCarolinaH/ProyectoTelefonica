using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Documento
    {
        [Key]
        public int DocumentoId { get; set; }


        [Required]
        [StringLength(75)]
        public string TipoDocumento { get; set; }


        [Required]
        [StringLength(75)]
        public string NumeroDocumento { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
