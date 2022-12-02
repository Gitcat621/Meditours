using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class CamionetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CamionetasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Camionetas.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCamioneta(Camionetas request)
        {
            try
            {
                if (request != null)
                {
                    Camionetas cam = new Camionetas();
                    cam.Modelo = request.Modelo;
                    cam.Capacidad = request.Capacidad;
                    cam.Urlimg = request.Urlimg;

                    _context.Camionetas.Add(cam);
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
                var destino = _context.Camionetas.Find(id);
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
            var destino = _context.Camionetas.Find(id);

            _context.Remove(destino);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
