using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="El nombre es un campo obligatorio")]
        [StringLength(150, ErrorMessage = "El campo nombre no puede exceder 150 caracteres")]
        public string Nombre { get; set; }

        [StringLength(9, ErrorMessage = " No puede exceder 9 caracteres")]
        public String? TelefonoFijo { get; set; }

        [StringLength(9, ErrorMessage = " No puede exceder 9 caracteres")]
        public String? TelefonoMovil { get; set; }

        [StringLength(75, ErrorMessage = " No puede exceder 75 caracteres")]
        public String? Correo { get; set; }


    }
}
