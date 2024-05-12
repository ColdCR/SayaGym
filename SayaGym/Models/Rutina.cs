namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Rutina
    {
        public int IdRutina { get; set; }
        [Required]
        public DateTime FechaRutina { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int DiaRutina { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<EjercicioRutina> EjerciciosRutina { get; set; }
    }
}
