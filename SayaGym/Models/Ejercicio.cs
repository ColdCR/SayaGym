namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ejercicios")]
    public class Ejercicio
    {
        [Key]
        public int IdEjercicio { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength (200)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string AreaATrabajar { get; set; }

        public ICollection<EjercicioRutina> Ejercicios { get; set; }
        public ICollection<EnfermedadUsuario> EnfermedadesUsuario { get; set; }
    }
}
