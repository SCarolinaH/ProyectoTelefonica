using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(9)]
        public String? TelefonoFijo { get; set; }

        [StringLength(9)]
        public  String? TelefonoMovil { get; set; }

        [StringLength(75)]
        public String? Correo { get; set; }

        public List<Direccion>? Direcciones { get; set; }

        public List<Documento>? Documentos { get; set; }

    }
}
