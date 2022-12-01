using Dapper;
using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Reservas.Include(z => z.Usuarios).Include(s => s.Itinerarios).Include(l => l.Itinerarios.Camionetas).Include(w => w.Itinerarios.Destinos).Include(o => o.Itinerarios.Paquetes).ToListAsync();
            return View(response);
        }

        [HttpGet]

        public async Task<IActionResult> ItinerariosDestinos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var destino = await _context.Itinerarios.Include(z => z.Destinos).Include(s => s.Camionetas).Where(x => x.FkDestino == id).ToListAsync();
                if (destino == null)
                {
                    return NotFound();
                }
                else
                    return View(destino);
            }
        }

        public IActionResult ItinerariosPaquetes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var destino = _context.Itinerarios.Include(z => z.Paquetes).Include(s => s.Camionetas).Where(x => x.FkPaquete == id).ToList();
                if (destino == null)
                {
                    return NotFound();
                }
                else
                    return View(destino);
            }
        }
        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-1TJ137V4; initial catalog = proyecto24BM; Integrated Security = true;");

        [HttpGet]
        public IActionResult Agregar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var itinerario = _context.Itinerarios.Find(id);
                if (itinerario == null)
                {
                    return NotFound();
                }
                else
                ViewBag.Itinerario = itinerario;
                return View(itinerario);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AgregarCarrito(Itinerarios response, int Usuario)
        {
            try
            {   Usuario = 1;
                if (response != null)
                {
                    await connection.QueryAsync<Itinerarios>("spInsertReserva", new { Usuario, response.PkItinerario }, commandType: CommandType.StoredProcedure);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }
    }
}
