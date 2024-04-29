namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Enfermedades")]
    public class Enfermedad
    {
        [Key]
        public int IdEnfermedad { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreEnfermedad { get; set; }
    }
}
