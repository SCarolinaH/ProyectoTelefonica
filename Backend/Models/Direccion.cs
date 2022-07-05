using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionId { get; set; }


        [Required]
        [StringLength(200)]
        public String CampoDireccion { get; set; }


        [Required]
        [StringLength(80)]
        public String Departamento { get; set; }


        [Required]
        [StringLength(80)]
        public String Municipio { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }





    }
}
