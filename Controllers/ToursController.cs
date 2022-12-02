using Meditours.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _context.Paquetes.ToListAsync();
            return View(response);
        }

        public async Task<IActionResult> Destinos()
        {
            var response = await _context.Destinos.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Destino(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var destino = _context.Destinos.Find(id);
                if (destino == null)
                {
                    return NotFound();
                }
                else
                ViewBag.Destinos = destino;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Paquete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var paquete = _context.Paquetes.Find(id);
                if (paquete == null)
                {
                    return NotFound();
                }
                else
                    ViewBag.Paquetes = paquete;
                return View();
            }
        }
    }
}
