using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SayaGym.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public int Rol { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public char Sexo { get; set; }

        [Required]
        [StringLength(8)]
        public string Teléfono { get; set; }

        [StringLength(255)]
        public string Dirección { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required]
        public decimal Peso { get; set; }

        [Required]
        public decimal Estatura { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public int Objetivo { get; set; }

        [DefaultValue('A')]
        public char Estado { get; set; }

        public Rutina Rutina { get; set; }
        public ICollection<AreasATrabajarUsuario> AreasATrabajar { get; set; }
        public ICollection<EnfermedadUsuario> EnfermedadesUsuario { get; set; }
    }
}
