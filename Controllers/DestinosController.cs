using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearDestino(Destinos request)
        {
            try
            {
                if (request != null)
                {
                    Destinos destino = new Destinos();
                    destino.Nombre = request.Nombre;
                    destino.Descripcion = request.Descripcion;
                    destino.Precio = request.Precio;
                    destino.Urlimg = request.Urlimg;

                    _context.Destinos.Add(destino);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
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
                var destino = _context.Destinos.Find(id);
                if (destino == null)
                {
                    return NotFound();
                }
                else
                return View(destino);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var destino = _context.Destinos.Find(id);

            _context.Remove(destino);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
