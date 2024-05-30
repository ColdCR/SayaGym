using Microsoft.EntityFrameworkCore;
using SayaGym.Models;
using Newtonsoft.Json;
using System.Text.Json;

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
                .HasOne(e => e.Rutina);

            modelBuilder.Entity<EnfermedadProhibidaEjercicio>()
                .HasKey(er => new { er.IdEjercicio, er.IdEnfermedad });

            modelBuilder.Entity<EnfermedadUsuario>()
                .HasKey(er => new { er.IdEnfermedad, er.IdUsuario });

            modelBuilder.Entity<AreasATrabajarUsuario>()
                .HasKey(er => new { er.AreaATrabajar, er.IdUsuario });

            modelBuilder.Entity<Usuario>()
            .HasData(
                new Usuario
                {
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

            modelBuilder.Entity<Enfermedad>().HasData(
                new Enfermedad
                {
                    IdEnfermedad = 1,
                    NombreEnfermedad = "Hipertensión",
                },
                new Enfermedad
                {
                    IdEnfermedad = 2,
                    NombreEnfermedad = "Diabetes",
                },
                new Enfermedad
                {
                    IdEnfermedad = 3,
                    NombreEnfermedad = "Problemas de espalda",
                },
                new Enfermedad
                {
                    IdEnfermedad = 4,
                    NombreEnfermedad = "Problemas de rodilla",
                },
                new Enfermedad
                {
                    IdEnfermedad = 5,
                    NombreEnfermedad = "Asma",
                },
                new Enfermedad
                {
                    IdEnfermedad = 6,
                    NombreEnfermedad = "Enfermedad cardíaca",
                },
                new Enfermedad
                {
                    IdEnfermedad = 7,
                    NombreEnfermedad = "Artritis",
                },
                new Enfermedad
                {
                    IdEnfermedad = 8,
                    NombreEnfermedad = "Osteoporosis",
                }
            );

            //sacar todas las enfermedades el json
            string jsonString = File.ReadAllText("Ejercicios.json");
            JsonDocument document = JsonDocument.Parse(jsonString);
            List<Ejercicio> EjerciciosAInsertar = new List<Ejercicio>();
            List<EnfermedadProhibidaEjercicio> EnfermedadProhibidaEjercicioAInsertar = new List<EnfermedadProhibidaEjercicio>();
            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                int IdEjercicio = element.GetProperty("IdEjercicio").GetInt32();
                string Area = element.GetProperty("AreaATrabajar").GetString();
                string Nombre = element.GetProperty("Nombre").GetString();
                string Descripcion = element.GetProperty("Descripcion").GetString();
                Ejercicio Ejercicio = new Ejercicio
                {
                    IdEjercicio = IdEjercicio,
                    AreaATrabajar = Area,
                    Nombre = Nombre,
                    Descripcion = Descripcion
                };
                EjerciciosAInsertar.Add( Ejercicio );
                modelBuilder.Entity<Ejercicio>().HasData(Ejercicio);
                foreach (JsonElement elementEnfermedadProhibida in element.GetProperty("idEnfermedadProhibida").EnumerateArray())
                {
                    int IdEnfermedadProhibida = elementEnfermedadProhibida.GetInt32();
                    EnfermedadProhibidaEjercicio EnfermedadProhibida = new EnfermedadProhibidaEjercicio
                    {
                        Ejercicio = Ejercicio,
                        IdEjercicio = IdEjercicio
                    };
                    modelBuilder.Entity<EnfermedadProhibidaEjercicio>()
                        .HasData(
                            new {
                                IdEjercicio = IdEjercicio,
                                IdEnfermedad = IdEnfermedadProhibida,
                                EjercicioIdEjercicio = IdEjercicio,
                                EnfermedadIdEnfermedad = IdEnfermedadProhibida
                            }
                        );
                }
            }

            
            

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
