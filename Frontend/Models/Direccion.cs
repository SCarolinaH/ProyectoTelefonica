using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class Direccion
    {

        [Key]
        public int DireccionId { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [StringLength(200)]
        public String CampoDireccion { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(80, ErrorMessage = " No puede exceder 80 caracteres")]
        public String Departamento { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(80, ErrorMessage = " No puede exceder 9 caracteres")]
        public String Municipio { get; set; }

        public int ClienteId { get; set; }
    }
}
