namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EjerciciosRutina")]
    public class EjercicioRutina
    {
        [Key]
        public int IdRutina { get; set; }
        [Key]
        public int IdEjercicio { get; set; }

    }
}
