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
        //Hola
        public async Task<IActionResult> Index()
        {
            ViewData["Holbox"] = await _context.Destinos.Where(x => x.PkDestino == 1).FirstOrDefaultAsync();
            ViewData["Isla"] = await _context.Destinos.Where(x => x.PkDestino == 2).FirstOrDefaultAsync();
            ViewData["Cozumel"] = await _context.Destinos.Where(x => x.PkDestino == 3).FirstOrDefaultAsync();
            ViewData["Coloradas"] = await _context.Destinos.Where(x => x.PkDestino == 4).FirstOrDefaultAsync();
            ViewData["Tulum"] = await _context.Destinos.Where(x => x.PkDestino == 5).FirstOrDefaultAsync();
            ViewData["Chichen"] = await _context.Destinos.Where(x => x.PkDestino == 6).FirstOrDefaultAsync();
            ViewData["Xcaret"] = await _context.Destinos.Where(x => x.PkDestino == 7).FirstOrDefaultAsync();

            ViewData["PYucatan"] = await _context.Paquetes.Where(x => x.PkPaquete == 1).FirstOrDefaultAsync();
            ViewData["PChichen"] = await _context.Paquetes.Where(x => x.PkPaquete == 2).FirstOrDefaultAsync();
            ViewData["PXcaret"] = await _context.Paquetes.Where(x => x.PkPaquete == 3).FirstOrDefaultAsync();
            ViewData["PPuerto"] = await _context.Paquetes.Where(x => x.PkPaquete == 4).FirstOrDefaultAsync();
            ViewData["PIsla"] = await _context.Paquetes.Where(x => x.PkPaquete == 5).FirstOrDefaultAsync();
            ViewData["PCozumel"] = await _context.Paquetes.Where(x => x.PkPaquete == 6).FirstOrDefaultAsync();

            return View();
        }

        public async Task<IActionResult> IndexAdmin(int id)
        {
            var response = await _context.Destinos.ToListAsync();
            return View(response);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Contacto()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
