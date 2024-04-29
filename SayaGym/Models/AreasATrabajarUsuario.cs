namespace SayaGym.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class AreasATrabajarUsuario
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(20)]
        public string AreaATrabajar { get; set; }

    }
}
