namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EnfermedadesUsuario")]
    public class EnfermedadUsuario
    {
        [Key]
        public int IdEnfermedad { get; set; }

        [Key]
        public int IdUsuario { get; set; }

    }
}
