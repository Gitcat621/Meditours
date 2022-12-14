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
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(Usuarios request)
        {
            try
            {
                EncryptMD5 encrypt = new EncryptMD5();
                if (request != null)
                {
                    Usuarios usuario = new Usuarios();
                    usuario.Nombre = request.Nombre;
                    usuario.User = request.User;
                    usuario.password = encrypt.Encrypt(request.password);
                    usuario.FkRol = 3;

                    _context.Usuarios.Add(usuario);
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

        [HttpPost]
        public JsonResult LoginUser(string user, string Password)
        {
            try
            {
                var usuario = _context.Usuarios.First(s => s.User == user);
                EncryptMD5 encr = new EncryptMD5();
                var Dpassword = encr.Descrypt(usuario.password);

                var response = _context.Usuarios.Include(z => z.Roles).FirstOrDefault
                    (x => x.User == user && Dpassword == Password);

                if (response != null)
                {
                    if (response.Roles.Nombre == "Admin")
                    {
                        //se va a logearz
                        var id = response.PkUsuario;
                        return Json(new { success = true, admin = true, id = id });
                    }
                    return Json(new { success = true, admin = false });
                }
                else
                {
                    //Errors
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un eror" + ex.Message);
            }
        }

        public async Task<IActionResult> Usuarios()
        {
            var response = await _context.Usuarios.Include(z => z.Roles).ToListAsync();

            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.combo = _context.Roles.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.PkRol.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(Usuarios request)
        {
            try
            {
                EncryptMD5 encrypt = new EncryptMD5();
                if (request != null)
                {
                    Usuarios usuario = new Usuarios();
                    usuario.Nombre = request.Nombre;
                    usuario.User = request.User;
                    usuario.password = encrypt.Encrypt(request.password);
                    usuario.FkRol = request.FkRol;

                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Usuarios));
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
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                else
                ViewBag.combo = _context.Roles.Select(x => new SelectListItem
                {
                    Text = x.Nombre,
                    Value = x.PkRol.ToString()
                });
                return View(usuario);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditarUsuario(Usuarios request)
        {
            try
            {
                if (request != null)
                {
                    Usuarios usuario = new Usuarios();
                    usuario.Nombre = request.Nombre;
                    usuario.User = request.User;
                    usuario.password = request.password;
                    usuario.FkRol = request.FkRol;

                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Usuarios));
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception("Errors papu " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            var usuario = _context.Usuarios.Find(id);

            _context.Remove(usuario);

            _context.SaveChanges();

            return RedirectToAction(nameof(Usuarios));

        }
    }
}
