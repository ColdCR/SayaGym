using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SayaGym.Data;
using SayaGym.Models;

namespace SayaGym.Controllers
{
    [Authorize]
    public class SaludController : Controller
    {
        private readonly Contexto _context;
        private Usuario _usuario;
        private IHttpContextAccessor _contextAccessor;

        //metodo para obtener
        private Usuario GetInfoUsuario(int id)
        {
            Usuario Usuario = _context.Usuario.Find(id);
            Usuario.EnfermedadesUsuario = _context.EnfermedadesUsuario.Where(e => e.IdUsuario == Usuario.IdUsuario)?.ToList();
            Usuario.AreasATrabajar = _context.AreasATrabajarUsuario.Where(e => e.IdUsuario == Usuario.IdUsuario).ToList();
            return Usuario;
        }

        public SaludController(Contexto context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _contextAccessor = httpContextAccessor;
            int UserId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            if (UserId > 0) {
                //guardar la info del usuario que esta logueado
                _usuario = GetInfoUsuario(UserId);
            }
        }

        

        public async Task<IActionResult> Index()
        {
            return View(_usuario);
        }
    }
}
