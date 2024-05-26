using Microsoft.EntityFrameworkCore;
using SayaGym.Models;

namespace SayaGym.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rutina>()
                .HasKey(r => r.IdRutina); // Primary key for Rutina

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario); // Primary key for Usuario

            modelBuilder.Entity<Rutina>()
                .HasOne(r => r.Usuario) // One Rutina to one Usuario
                .WithOne(u => u.Rutina) // One Usuario to one Rutina (optional)
                .HasForeignKey<Rutina>(r => r.IdUsuario); // Foreign key in Rutina table

            modelBuilder.Entity<EjercicioRutina>()
                .HasKey(er => new { er.IdEjercicio, er.IdRutina });

            modelBuilder.Entity<EjercicioRutina>()
                .HasOne(e => e.Rutina);

            modelBuilder.Entity<EnfermedadProhibidaEjercicio>()
                .HasKey(er => new { er.IdEjercicio, er.IdEnfermedad });

            modelBuilder.Entity<EnfermedadUsuario>()
                .HasKey(er => new { er.IdEnfermedad, er.IdUsuario });

            modelBuilder.Entity<AreasATrabajarUsuario>()
                .HasKey(er => new { er.AreaATrabajar, er.IdUsuario });

            modelBuilder.Entity<Usuario>()
            .HasData(
                new Usuario {
                    IdUsuario = 1,
                    Cedula = "11111111",
                    Rol = 0,
                    Contraseña = "admin",
                    Nombre = "Admin",
                    Sexo = 'M',
                    Teléfono = "00000000",
                    Correo = "admin@gmail.com",
                    Peso = 80,
                    Estatura = 170,
                    FechaDeNacimiento = DateTime.Now,
                    Objetivo = 0,
                    Estado = 'A',
                    Dirección = ""
                }
            );

            //modelBuilder.Entity<Enfermedad>().HasData(
            //    new Enfermedad
            //    {
            //        IdEnfermedad = 1,
            //        NombreEnfermedad = "Obesidad"
            //    },
            //    new Enfermedad
            //    {
            //        IdEnfermedad = 2,
            //        NombreEnfermedad = "Asma"
            //    }
            //);
        }

        public DbSet<Ejercicio> Ejercicio { get; set; }
        public DbSet<EjercicioRutina> EjercicioRutina { get; set; }
        public DbSet<Enfermedad> Enfermedad { get; set; }

        public DbSet<EnfermedadProhibidaEjercicio> EnfermedadProhibidaEjercicio { get; set; }

        public DbSet<EnfermedadUsuario> EnfermedadesUsuario { get; set; }

        public DbSet<Rutina> Rutina { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<AreasATrabajarUsuario> AreasATrabajarUsuario { get; set; }

    }
}
