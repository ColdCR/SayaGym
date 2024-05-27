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
            return View(listaUsuarios);
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
