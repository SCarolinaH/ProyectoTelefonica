using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class Documento
    {
        [Key]
        public int DocumentoId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(75, ErrorMessage = " No puede exceder 75 caracteres")]
        public string TipoDocumento { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(75, ErrorMessage = " No puede exceder 75 caracteres")]
        public string NumeroDocumento { get; set; }

        public int ClienteId { get; set; }


    }
}
