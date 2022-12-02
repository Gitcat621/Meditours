using Dapper;
using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Reservas.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.combo1 = _context.Usuarios.Select(x => new SelectListItem
            {
                Text = x.User,
                Value = x.PkUsuario.ToString()
            });
            ViewBag.combo2 = _context.Itinerarios.Select(x => new SelectListItem
            {
                Text = x.Dia,
                Value = x.PkItinerario.ToString()
            });
            return View();
        }
        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-1TJ137V4; initial catalog = meditours; Integrated Security = true;");
        [HttpPost]
        public async Task<IActionResult> CrearReserva(Usuarios Usuario,Itinerarios response)
        {
            try
            {
                if (response != null)
                {
                    await connection.QueryAsync<Itinerarios>("spInsertReserva", new { Usuario.PkUsuario, response.PkItinerario }, commandType: CommandType.StoredProcedure);
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index));
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
                var destino = _context.Reservas.Find(id);
                if (destino == null)
                {
                    return NotFound();
                }
                else
                ViewBag.combo1 = _context.Usuarios.Select(x => new SelectListItem
                {
                    Text = x.User,
                    Value = x.PkUsuario.ToString()
                });
                ViewBag.combo2 = _context.Itinerarios.Select(x => new SelectListItem
                {
                    Text = x.Dia,
                    Value = x.PkItinerario.ToString()
                });
                return View(destino);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var destino = _context.Reservas.Find(id);

            _context.Remove(destino);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
