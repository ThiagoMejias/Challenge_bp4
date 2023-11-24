using System.ComponentModel.DataAnnotations;

namespace ChallengeBp4.Modelos
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public string Cuit { get; set; }

        public string Domicilio { get; set; }
        [Required]
        public string TelefonoCelular { get; set; }
        [Required]
        public string Email { get; set; }



    }
}
