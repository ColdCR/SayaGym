namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ejercicios")]
    public class Ejercicio
    {
        //constante con las areas a trabajar
        public static readonly string[] AreasATrabajarDisponibles = new string[] { "Pecho", "Espalda", "Brazos", "Piernas", "Abdomen" };
        [Key]
        public int IdEjercicio { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength (500)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string AreaATrabajar { get; set; }

        public ICollection<EjercicioRutina> Ejercicios { get; set; }
        public ICollection<EnfermedadProhibidaEjercicio> EnfermedadesProhibidasUsuario { get; set; }
    }
}
