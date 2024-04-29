namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EnfermedadesProhibidasEjercicios")]
    public class EnfermedadProhibidaEjercicio
    {
        [Key]
        public int IdEjercicio { get; set; }

        [Key]
        public int IdEnfermedad { get; set; }
    }
}
