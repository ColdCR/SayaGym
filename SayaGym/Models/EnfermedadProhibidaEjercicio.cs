namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EnfermedadesProhibidasEjercicios")]
    public class EnfermedadProhibidaEjercicio
    {

        public int IdEjercicio { get; set; }


        public int IdEnfermedad { get; set; }
        public Ejercicio Ejercicio { get; set; }
        public Enfermedad Enfermedad { get; set; }
    }
}
