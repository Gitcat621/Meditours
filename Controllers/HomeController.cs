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

        public async Task<IActionResult> Index()
        {
            var response = await _context.Destinos.ToListAsync();

            ViewData["Holbox"] = await _context.Destinos.Where(x => x.PkDestino == 1).FirstOrDefaultAsync();
            ViewData["Isla"] = await _context.Destinos.Where(x => x.PkDestino == 2).FirstOrDefaultAsync();
            ViewData["Cozumel"] = await _context.Destinos.Where(x => x.PkDestino == 3).FirstOrDefaultAsync();
            ViewData["Coloradas"] = await _context.Destinos.Where(x => x.PkDestino == 4).FirstOrDefaultAsync();
            ViewData["Yucatan"] = await _context.Destinos.Where(x => x.PkDestino == 5).FirstOrDefaultAsync();
            ViewData["Chichen"] = await _context.Destinos.Where(x => x.PkDestino == 6).FirstOrDefaultAsync();
            ViewData["Xcaret"] = await _context.Destinos.Where(x => x.PkDestino == 7).FirstOrDefaultAsync();
            ViewData["Puerto"] = await _context.Destinos.Where(x => x.PkDestino == 8).FirstOrDefaultAsync();

            return View(response);
        }

        public async Task<IActionResult> IndexAdmin()
        {
            var response = await _context.Destinos.ToListAsync();
            ViewData["User"] = await _context.Usuarios.Where(x => x.PkUsuario == 4).FirstOrDefaultAsync();
            return View(response);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
