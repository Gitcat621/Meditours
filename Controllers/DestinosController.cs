using Meditours.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class DestinosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Destinos.ToListAsync();
            return View(response);
        }

        public async Task<IActionResult> Paquetes()
        {
            ViewData["Holbox"] = await _context.Destinos.Where(x => x.PkDestino == 1).FirstOrDefaultAsync();
            ViewData["Isla"] = await _context.Destinos.Where(x => x.PkDestino == 2).FirstOrDefaultAsync();
            ViewData["Cozumel"] = await _context.Destinos.Where(x => x.PkDestino == 3).FirstOrDefaultAsync();
            ViewData["Coloradas"] = await _context.Destinos.Where(x => x.PkDestino == 4).FirstOrDefaultAsync();
            ViewData["Yucatan"] = await _context.Destinos.Where(x => x.PkDestino == 5).FirstOrDefaultAsync();
            ViewData["Chichen"] = await _context.Destinos.Where(x => x.PkDestino == 6).FirstOrDefaultAsync();
            ViewData["Xcaret"] = await _context.Destinos.Where(x => x.PkDestino == 7).FirstOrDefaultAsync();
            ViewData["Puerto"] = await _context.Destinos.Where(x => x.PkDestino == 8).FirstOrDefaultAsync();
            return View();
        }

        [HttpGet]
        public IActionResult Comprar(int? id)
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
                return View(destino);
            }
        }

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
                    ViewBag.Destino = destino;
                    return View();
            }
        }

    }
}
