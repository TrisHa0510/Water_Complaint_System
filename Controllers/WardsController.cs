using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterComplaintSystem.Data;
using WaterComplaintSystem.Models;

namespace WaterComplaintSystem.Controllers
{
    public class WardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Practical 10: Response caching demonstration
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            var wards = await _context.Wards
                .Include(w => w.Complaints)
                .Include(w => w.Workers)
                .ToListAsync();
            return View(wards);
        }

        // GET: Wards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ward = await _context.Wards
                .Include(w => w.Complaints)
                .Include(w => w.Workers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ward == null)
                return NotFound();

            return View(ward);
        }

        // GET: Wards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Area,Description")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ward);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ward created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(ward);
        }

        // GET: Wards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
                return NotFound();

            return View(ward);
        }

        // POST: Wards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Area,Description")] Ward ward)
        {
            if (id != ward.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ward);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Ward updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardExists(ward.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ward);
        }

        // GET: Wards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ward = await _context.Wards
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ward == null)
                return NotFound();

            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ward = await _context.Wards.FindAsync(id);
            if (ward != null)
            {
                _context.Wards.Remove(ward);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ward deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool WardExists(int id)
        {
            return _context.Wards.Any(e => e.Id == id);
        }
    }
}
