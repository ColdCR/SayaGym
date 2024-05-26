using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SayaGym.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Display(Name = "Cédula")]
        [Required]
        public string Cedula { get; set; }

        /*
        0 = administrador
        1 = entrenador
        2 = cliente
         */
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
        [Display(Name = "Peso en Kilogramos")]
        public decimal Peso { get; set; }

        [Required]
        [Display(Name = "Estatura en Metros")]
        public decimal Estatura { get; set; }

        //obtener la edad
        public int Edad {
            get {
                DateTime today = DateTime.Now;

                TimeSpan ageDifference = today.Subtract(this.FechaDeNacimiento);
                int years = (int)ageDifference.TotalDays / 365;
                return years;
            }
        }

        public decimal IMC
        {
            get {
                return this.Peso / (this.Estatura * this.Estatura);
            }
        }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        public int Objetivo { get; set; }

        [DefaultValue('A')]
        public char Estado { get; set; }

        public Rutina Rutina { get; set; }
        public ICollection<AreasATrabajarUsuario> AreasATrabajar { get; set; }
        public ICollection<EnfermedadUsuario> EnfermedadesUsuario { get; set; }
    }
}
