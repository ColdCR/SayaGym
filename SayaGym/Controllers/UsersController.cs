using Microsoft.AspNetCore.Mvc;
using SayaGym.Models;
using SayaGym.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SayaGym.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly Contexto _context = null;


        public UsersController (Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var listaUsuarios = await _context.Usuario.ToListAsync();
            var listaFiltered = 
                from usuario in listaUsuarios
                where usuario.Rol != 0
                select usuario;
            return View(listaFiltered);
        }

        private List<Enfermedad> GetEnfermedades()
        {
            _context.Enfermedad.ToList();

            return _context.Enfermedad.ToList();
        }

        private Usuario GetUsuario(int id)
        {
            Usuario Usuario = _context.Usuario.Find(id);
            Usuario.EnfermedadesUsuario = _context.EnfermedadesUsuario.Where(e => e.IdUsuario == Usuario.IdUsuario).ToList();
            Usuario.AreasATrabajar = _context.AreasATrabajarUsuario.Where(e => e.IdUsuario == Usuario.IdUsuario).ToList();
            return Usuario;
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.Enfermedades = GetEnfermedades();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Enfermedades = GetEnfermedades();
            Usuario Usuario = GetUsuario(id);
            return View(Usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuarioEditado)
        {
            Usuario Usuario = GetUsuario(usuarioEditado.IdUsuario);//obtener el usuario actual de la base de datos

            //solo tomar en cuenta campos que se pueden editar
            Usuario.Nombre = usuarioEditado.Nombre;
            Usuario.Rol = usuarioEditado.Rol;
            Usuario.Sexo = usuarioEditado.Sexo;
            Usuario.Correo = usuarioEditado.Correo;
            Usuario.Teléfono = usuarioEditado.Teléfono;
            Usuario.Dirección = usuarioEditado.Dirección;
            Usuario.Peso = usuarioEditado.Peso;
            Usuario.Estatura = usuarioEditado.Estatura;
            Usuario.FechaDeNacimiento = usuarioEditado.FechaDeNacimiento;
            Usuario.Objetivo = usuarioEditado.Objetivo;
            Usuario.Estado = usuarioEditado.Estado;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //estos datos los tomo del formulario ya que estos campos no vienen como tal en el modelo de Usuario
                    var FormCollection = Request.Form;
                    var AreasForm = FormCollection["AreasATrabajar[]"];
                    var EnfermedadesForm = FormCollection["Enfermedades[]"];


                    //verificamos que no exista usuario con la misma cedula
                    bool findedUser = _context.Usuario.Any(u => u.Cedula == Usuario.Cedula && Usuario.IdUsuario != u.IdUsuario);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con esa cédula");
                    }

                    //verificamos que no exista usuario con el mismo correo
                    findedUser = _context.Usuario.Any(u => u.Correo == Usuario.Correo && Usuario.IdUsuario != u.IdUsuario);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con ese correo");
                    }

                    List<EnfermedadUsuario> EnfermedadesUsuario = new List<EnfermedadUsuario>();

                    foreach (var EnfermedadForm in EnfermedadesForm)
                    {
                        int IdEnfermedad = int.Parse(EnfermedadForm);
                        var EnfermedadActualUsuario = 
                            (from enfermedad in Usuario.EnfermedadesUsuario.ToList()
                            where enfermedad.IdEnfermedad == IdEnfermedad
                            select enfermedad).FirstOrDefault();

                        if (EnfermedadActualUsuario != null)
                        {
                            EnfermedadesUsuario.Add((EnfermedadUsuario)EnfermedadActualUsuario);
                        } 
                        else
                        {
                            Enfermedad Enfermedad = _context.Enfermedad.Find(IdEnfermedad);
                            EnfermedadUsuario NuevaEnfermedad = new EnfermedadUsuario
                            {
                                IdUsuario = Usuario.IdUsuario,
                                IdEnfermedad = IdEnfermedad,
                                Usuario = Usuario,
                                Enfermedad = Enfermedad
                            };
                            EnfermedadesUsuario.Add(NuevaEnfermedad);
                        }
                    }

                    Usuario.EnfermedadesUsuario = EnfermedadesUsuario;

                    List<AreasATrabajarUsuario> AreasUsuario = new();
                    foreach (var AreaForm in AreasForm)
                    {
                        var AreaActualUsuario =
                            (from area in Usuario.AreasATrabajar.ToList()
                             where area.AreaATrabajar == AreaForm
                             select area).FirstOrDefault();

                        if (AreaActualUsuario != null)
                        {
                            AreasUsuario.Add(AreaActualUsuario);
                        }
                        else
                        {
                            AreasATrabajarUsuario Area = new AreasATrabajarUsuario
                            {
                                IdUsuario = Usuario.IdUsuario,
                                AreaATrabajar = AreaForm,
                                Usuario = Usuario
                            };

                            AreasUsuario.Add(Area);
                        }
                    }

                    Usuario.AreasATrabajar = AreasUsuario;

                    //guardamos el usuario en la base de datos
                    _context.Usuario.Update(Usuario);
                    _context.SaveChanges();

                    transaction.Commit(); // Confirmar la transacción
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    transaction.Rollback(); // Revertir la transacción
                }
            }
            ViewBag.Enfermedades = GetEnfermedades();
            return View(Usuario);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var Usuario = _context.Usuario.Find(id);
            if (Usuario != null) {
                _context.Usuario.Remove(Usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //estos datos los tomo del formulario ya que estos campos no vienen como tal en el modelo de Usuario
                    var FormCollection = Request.Form;
                    var AreasForm = FormCollection["AreasATrabajar[]"];
                    var EnfermedadesForm = FormCollection["Enfermedades[]"];


                    usuario.Estado = 'A';

                    //verificamos que no exista usuario con la misma cedula
                    bool findedUser = _context.Usuario.Any(u => u.Cedula == usuario.Cedula);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con esa cédula");
                    }

                    //verificamos que no exista usuario con el mismo correo
                    findedUser = _context.Usuario.Any(u => u.Correo == usuario.Correo);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con ese correo");
                    }

                    //guardamos el usuario en la base de datos
                    _context.Usuario.Add(usuario);

                    // Guardar los cambios en la base de datos
                    _context.SaveChanges();

                    foreach (var EnfermedadForm in EnfermedadesForm)
                    {
                        int idEnfermedad = int.Parse(EnfermedadForm);
                        Enfermedad Enfermedad = _context.Enfermedad.Find(idEnfermedad);
                        if (Enfermedad == null) continue;
                        EnfermedadUsuario EnfermedadUsuario = new EnfermedadUsuario
                        {
                            IdUsuario = usuario.IdUsuario,
                            IdEnfermedad = idEnfermedad,
                            Usuario = usuario,
                            Enfermedad = Enfermedad

                        };
                        _context.EnfermedadesUsuario.Add(EnfermedadUsuario);
                        _context.SaveChanges();
                    }
                    foreach (string AreaForm in AreasForm)
                    {

                        AreasATrabajarUsuario Area = new AreasATrabajarUsuario
                        {
                            IdUsuario = usuario.IdUsuario,
                            AreaATrabajar = AreaForm,
                            Usuario = usuario
                        };
                        _context.AreasATrabajarUsuario.Add(Area);
                        _context.SaveChanges();
                    }


                    transaction.Commit(); // Confirmar la transacción
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    transaction.Rollback(); // Revertir la transacción
                }
            }

            return Create();
        }

        public IActionResult Details(int id)
        {
            Usuario Usuario = GetUsuario(id);
            return View(Usuario);
        }
        private IEnumerable<Enfermedad> GetEnfermedadesDisponibles()
        {
            List<Enfermedad> enfermedades = new List<Enfermedad> {
                new Enfermedad
                {
                    IdEnfermedad = 1,
                    NombreEnfermedad = "Obesidad"
                },
                new Enfermedad
                {
                    IdEnfermedad = 2,
                    NombreEnfermedad = "Asma"
                },
            };
            return enfermedades;
        }



    }
}
