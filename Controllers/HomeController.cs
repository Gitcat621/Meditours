using Meditours.Context;
using Meditours.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Meditours.Controllers

{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
            var response = await _context.usuario.Include(z => z.Roles).ToListAsync();

            return View(response);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(usuario request)
        {
            try
            {
                if (request != null)
                {
                    usuario usuario = new usuario();
                    usuario.Nombre = request.Nombre;
                    usuario.User = request.User;
                    usuario.password = request.password;
                    usuario.FkRol = 1;

                    _context.usuario.Add(usuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Login));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var usuario = _context.usuario.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                else
                    return View(usuario);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
