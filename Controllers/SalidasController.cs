using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class SalidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalidasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Itinerarios.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.combo1 = _context.Camionetas.Select(x => new SelectListItem
            {
                Text = x.Modelo,
                Value = x.PkCamioneta.ToString()
            });
            ViewBag.combo2 = _context.Destinos.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.PkDestino.ToString()
            });
            ViewBag.combo3 = _context.Paquetes.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.PkPaquete.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearSalida(Itinerarios request)
        {
            try
            {
                if (request != null)
                {
                    Itinerarios destino = new Itinerarios();
                    destino.Dia = request.Dia;
                    destino.HraSalida = request.HraSalida;
                    destino.Capacidad = request.Capacidad;
                    destino.FkCamioneta = request.FkCamioneta;
                    destino.FkDestino = request.FkDestino;
                    destino.FkPaquete = request.FkPaquete;

                    _context.Itinerarios.Add(destino);
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
                var destino = _context.Itinerarios.Find(id);
                if (destino == null)
                {
                    return NotFound();
                }
                else
                ViewBag.combo1 = _context.Camionetas.Select(x => new SelectListItem
                {
                    Text = x.Modelo,
                    Value = x.PkCamioneta.ToString()
                });
                ViewBag.combo2 = _context.Destinos.Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.PkDestino.ToString()
                });
                ViewBag.combo3 = _context.Paquetes.Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.PkPaquete.ToString()
                });
                return View(destino);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var destino = _context.Itinerarios.Find(id);

            _context.Remove(destino);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
