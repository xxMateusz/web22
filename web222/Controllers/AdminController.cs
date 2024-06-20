using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using web222.Context;
using web222.Models;

namespace web222.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var formData = await _context.FormData.ToListAsync();
            var pracodawcy = await _context.Pracodawcy.ToListAsync();
            var zones = await _context.Zones.ToListAsync();

            var model = new AdminViewModel
            {
                FormData = formData,
                Pracodawcy = pracodawcy,
                Zones = zones
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFormData(int id)
        {
            var formData = await _context.FormData.FindAsync(id);
            if (formData != null)
            {
                _context.FormData.Remove(formData);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePracodawca(int id)
        {
            var pracodawca = await _context.Pracodawcy.FindAsync(id);
            if (pracodawca != null)
            {
                _context.Pracodawcy.Remove(pracodawca);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteZone(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            if (zone != null)
            {
                _context.Zones.Remove(zone);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }

    public class AdminViewModel
    {
        public IEnumerable<FormData> FormData { get; set; }
        public IEnumerable<Pracodawca> Pracodawcy { get; set; }
        public IEnumerable<Zone> Zones { get; set; }
    }
}
