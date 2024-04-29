namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Rutina
    {
        [Key]
        public int IdRutina { get; set; }
        [Required]
        public DateTime FechaRutina { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}
