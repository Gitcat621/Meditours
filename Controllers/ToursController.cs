using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meditours.Context;
using Microsoft.Extensions.Logging;

namespace Meditours.Controllers
{
    public class ToursController : Controller
    {
        private readonly ILogger<ToursController> _logger;
        private readonly ApplicationDbContext _context;

        public ToursController(ILogger<ToursController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _context.Destinos.ToListAsync();

            return View(response);
        }
    }
}
