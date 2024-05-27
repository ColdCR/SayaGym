namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EjerciciosRutina")]
    public class EjercicioRutina
    {

        public int IdRutina { get; set; }

        public int IdEjercicio { get; set; }

        [Required]
        public int DiaEjercicio { get; set; }

        public Rutina Rutina { get; set; }

        public Ejercicio Ejercicio { get; set; }

    }
}
