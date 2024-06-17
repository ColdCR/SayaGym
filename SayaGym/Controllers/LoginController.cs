using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SayaGym.Data;
using System.Security.Claims;

namespace SayaGym.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _context = null;
        public LoginController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //proceso de loguearse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string correo, string contraseña)
        {
            //verificar si existe el usuario
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == correo && u.Contraseña == contraseña);
            if (usuario != null)
            {
                if (usuario.Estado == 'I')
                {
                    TempData["MensajeError"] = "El usuario se encuentra inactivado";
                    return View();
                }
                //loguear al usuario
                var UserClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Email, usuario.Correo),
                    new Claim(ClaimTypes.Role, usuario.Rol.ToString()),// guardar el rol del usuario
                    new Claim("Id", usuario.IdUsuario.ToString())
                };
                var GrandmaIdentity = new ClaimsIdentity(UserClaims, "User Identity");
                var UserPrincipal = new ClaimsPrincipal(GrandmaIdentity);

                //guardar el usuario en la sesion
                await HttpContext.SignInAsync(UserPrincipal);
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

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
