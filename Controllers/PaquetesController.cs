using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaquetesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Paquetes.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPaquete(Paquetes request)
        {
            try
            {
                if (request != null)
                {
                    Paquetes destino = new Paquetes();
                    destino.Nombre = request.Nombre;
                    destino.Descripcion = request.Descripcion;
                    destino.Precio = request.Precio;
                    destino.Urlimg = request.Urlimg;

                    _context.Paquetes.Add(destino);
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
                var paq = _context.Paquetes.Find(id);
                if (paq == null)
                {
                    return NotFound();
                }
                else
                    return View(paq);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var destino = _context.Destinos.Find(id);

            _context.Remove(destino);

            _context.SaveChanges();

            return RedirectToAction(nameof(Usuarios));

        }
    }
}
