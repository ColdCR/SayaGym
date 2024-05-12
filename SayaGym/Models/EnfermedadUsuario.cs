namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EnfermedadesUsuario")]
    public class EnfermedadUsuario
    {

        public int IdEnfermedad { get; set; }


        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

    }
}
