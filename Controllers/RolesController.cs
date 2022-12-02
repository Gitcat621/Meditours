using Meditours.Context;
using Meditours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Meditours.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _context.Roles.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol(Roles request)
        {
            try
            {
                if (request != null)
                {
                    Roles rol = new Roles();
                    rol.Nombre = request.Nombre;

                    _context.Roles.Add(rol);
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
                var Rol = _context.Roles.Find(id);
                if (Rol == null)
                {
                    return NotFound();
                }
                else
                return View(Rol);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var Rol = _context.Roles.Find(id);

            _context.Remove(Rol);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
