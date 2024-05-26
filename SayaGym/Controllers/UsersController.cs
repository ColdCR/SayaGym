using Microsoft.AspNetCore.Mvc;
using SayaGym.Models;
using SayaGym.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Security.Claims;

namespace SayaGym.Controllers
{
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

        private Usuario GetUsuario(int Id)
        {
            Usuario Usuario = _context.Usuario.Find(Id);
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
        public IActionResult Edit(int Id)
        {

            ViewBag.Enfermedades = GetEnfermedades();
            Usuario Usuario = GetUsuario(Id);
            return View(Usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario UsuarioEditado)
        {
            Usuario Usuario = GetUsuario(UsuarioEditado.IdUsuario);//obtener el usuario actual de la base de datos

            //solo tomar en cuenta campos que se pueden editar
            Usuario.Nombre = UsuarioEditado.Nombre;
            Usuario.Rol = UsuarioEditado.Rol;
            Usuario.Sexo = UsuarioEditado.Sexo;
            Usuario.Correo = UsuarioEditado.Correo;
            Usuario.Teléfono = UsuarioEditado.Teléfono;
            Usuario.Dirección = UsuarioEditado.Dirección;
            Usuario.Peso = UsuarioEditado.Peso;
            Usuario.Estatura = UsuarioEditado.Estatura;
            Usuario.FechaDeNacimiento = UsuarioEditado.FechaDeNacimiento;
            Usuario.Objetivo = UsuarioEditado.Objetivo;
            Usuario.Estado = UsuarioEditado.Estado;
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
        public IActionResult Delete(int Id)
        {

            var Usuario = _context.Usuario.Find(Id);
            if (Usuario != null) {
                _context.Usuario.Remove(Usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario Usuario)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //estos datos los tomo del formulario ya que estos campos no vienen como tal en el modelo de Usuario
                    var FormCollection = Request.Form;
                    var AreasForm = FormCollection["AreasATrabajar[]"];
                    var EnfermedadesForm = FormCollection["Enfermedades[]"];


                    Usuario.Estado = 'A';

                    //verificamos que no exista usuario con la misma cedula
                    bool findedUser = _context.Usuario.Any(u => u.Cedula == Usuario.Cedula);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con esa cédula");
                    }

                    //verificamos que no exista usuario con el mismo correo
                    findedUser = _context.Usuario.Any(u => u.Correo == Usuario.Correo);
                    if (findedUser)
                    {
                        throw new Exception("Ya existe un usuario con ese correo");
                    }

                    //guardamos el usuario en la base de datos
                    _context.Usuario.Add(Usuario);

                    // Guardar los cambios en la base de datos
                    _context.SaveChanges();

                    foreach (var EnfermedadForm in EnfermedadesForm)
                    {
                        int idEnfermedad = int.Parse(EnfermedadForm);
                        Enfermedad Enfermedad = _context.Enfermedad.Find(idEnfermedad);
                        if (Enfermedad == null) continue;
                        EnfermedadUsuario EnfermedadUsuario = new EnfermedadUsuario
                        {
                            IdUsuario = Usuario.IdUsuario,
                            IdEnfermedad = idEnfermedad,
                            Usuario = Usuario,
                            Enfermedad = Enfermedad

                        };
                        _context.EnfermedadesUsuario.Add(EnfermedadUsuario);
                        _context.SaveChanges();
                    }
                    foreach (string AreaForm in AreasForm)
                    {

                        AreasATrabajarUsuario Area = new AreasATrabajarUsuario
                        {
                            IdUsuario = Usuario.IdUsuario,
                            AreaATrabajar = AreaForm,
                            Usuario = Usuario
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //proceso de loguearse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Correo, string Contraseña)
        {
            //verificar si existe el usuario
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == Correo && u.Contraseña == Contraseña);
            if (usuario != null)
            {
                //loguear al usuario
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Email, usuario.Correo),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString()),// guardar el rol del usuario
                    new Claim("Id", usuario.IdUsuario.ToString())
                };
                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(grandmaIdentity);

                //guardar el usuario en la sesion
                await HttpContext.SignInAsync(userPrincipal);
                //redireccionar al index
                return RedirectToAction("Index", "Home");

            }
            else
            {
                //no se encontro el usuario
                TempData["MensajeError"] = "El usuario con ese correo y contraseña no existe";
                return View();
            }
        }
    }
}
