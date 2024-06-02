using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SayaGym.Models
{

    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La Cédula es requerida")]
        [ValidarCedula(ErrorMessage = "La Cédula no tiene el formato correcto")]
        public string Cedula { get; set; }

        /*
        0 = administrador
        1 = entrenador
        2 = cliente
         */
        [Required]
        public int Rol { get; set; }

        public string RolTexto {
            get 
            {
                switch (this.Objetivo)
                {
                    case 0: return "Administrador";
                    case 1: return "Entrenador";
                    case 2: return "Cliente";
                    default: return "Desconocido";
                }
            } 
        }

        [Required(ErrorMessage = "La clave es requerida")]
        [Display(Name = "Clave")]
        [StringLength(25)]
        [MinLength(5, ErrorMessage = "La clave debe contener minimo 5 caracteres")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [NoNumerosOCaracteresEspeciales(ErrorMessage = "El nombre contiene caracteres invalidos")]
        public string Nombre { get; set; }

        [Required]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(8)]
        [MinLength(8, ErrorMessage = "El teléfono debe ser de minimo 8 caracteres")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El teléfono contiene caracteres invalidos")]
        public string Teléfono { get; set; }

        [StringLength(255)]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El peso es requerido")]
        [Display(Name = "Peso en Kilogramos")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "La estatura es requerida")]
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

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        public int Objetivo { get; set; }

        public string ObjetivoTexto
        {
            get
            {
                switch(this.Objetivo)
                {
                    case 0: return "Mantenerse";
                    case 1: return "Bajar de peso";
                    case 2: return "Tonificar";
                    default: return "Desconocido";
                }
            }
        }

        [DefaultValue('A')]
        public char Estado { get; set; }

        public Rutina Rutina { get; set; }
        public ICollection<AreasATrabajarUsuario> AreasATrabajar { get; set; }
        public ICollection<EnfermedadUsuario> EnfermedadesUsuario { get; set; }
    }

    //clase para un atributo personalizado para validar la cedula
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class ValidarCedula : ValidationAttribute
    {
        private const string CedulaRegex = @"^(1[0-9]|[2-8][0-7][0-9]|[9][0-1][0-9])\d{6}$";

        public override bool IsValid(object value)
        {
            if (value is string email)
            {
                return Regex.IsMatch(email, CedulaRegex);
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class NoNumerosOCaracteresEspeciales : ValidationAttribute
    {
        private const string allowedCharactersRegex = @"^[a-zA-Z\s]+$";

        public override bool IsValid(object value)
        {
            if (value is string text)
            {
                return Regex.IsMatch(text, allowedCharactersRegex);
            }

            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class SoloNumeros : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string text)
            {
                return text.All(char.IsDigit);
            }

            return false;
        }
    }

}
