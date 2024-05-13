using Microsoft.AspNetCore.Mvc;
using SayaGym.Models;
using SayaGym.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
