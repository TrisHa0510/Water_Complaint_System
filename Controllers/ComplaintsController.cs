using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WaterComplaintSystem.Data;
using WaterComplaintSystem.Models;

namespace WaterComplaintSystem.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ComplaintsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // Practical 15: Read - Display all complaints with filtering
        // Practical 9: Query string demonstration
        public async Task<IActionResult> Index(string status, string priority, int? wardId)
        {
            // Store filter values in session
            if (!string.IsNullOrEmpty(status))
                HttpContext.Session.SetString("FilterStatus", status);
            if (!string.IsNullOrEmpty(priority))
                HttpContext.Session.SetString("FilterPriority", priority);

            var complaints = _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Ward)
                .Include(c => c.AssignedWorker)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(status))
                complaints = complaints.Where(c => c.Status == status);

            if (!string.IsNullOrEmpty(priority))
                complaints = complaints.Where(c => c.Priority == priority);

            if (wardId.HasValue)
                complaints = complaints.Where(c => c.WardId == wardId.Value);

            // Practical 9: ViewBag for dropdowns
            ViewBag.Wards = await _context.Wards.ToListAsync();
            ViewBag.SelectedStatus = status;
            ViewBag.SelectedPriority = priority;
            ViewBag.SelectedWardId = wardId;

            return View(await complaints.OrderByDescending(c => c.CreatedDate).ToListAsync());
        }

        // Practical 15: Read - Display single complaint details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var complaint = await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Ward)
                .Include(c => c.AssignedWorker)
                .Include(c => c.Photos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (complaint == null)
                return NotFound();

            // Practical 9: Cookie demonstration - track last viewed complaint
            Response.Cookies.Append("LastViewedComplaint", id.ToString(), new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });

            return View(complaint);
        }

        // Practical 15: Create - GET
        public IActionResult Create()
        {
            // Populate dropdowns
            ViewBag.Citizens = new SelectList(_context.Citizens, "Id", "Name");
            ViewBag.Wards = new SelectList(_context.Wards, "Id", "Name");
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name");
            return View();
        }

        // Practical 15: Create - POST with file upload
        // Practical 14: Model validation
        // Practical 8: Async operation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Status,Priority,CitizenId,WardId,AssignedWorkerId")] Complaint complaint, IFormFile? photo)
        {
            // Practical 14: Explicit validation
            if (string.IsNullOrWhiteSpace(complaint.Title))
                ModelState.AddModelError("Title", "Title cannot be empty");

            if (ModelState.IsValid)
            {
                complaint.CreatedDate = DateTime.Now;
                _context.Add(complaint);
                await _context.SaveChangesAsync();

                // Handle file upload
                if (photo != null && photo.Length > 0)
                {
                    await SaveComplaintPhotoAsync(complaint.Id, photo);
                }

                TempData["SuccessMessage"] = "Complaint created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdowns on validation failure
            ViewBag.Citizens = new SelectList(_context.Citizens, "Id", "Name", complaint.CitizenId);
            ViewBag.Wards = new SelectList(_context.Wards, "Id", "Name", complaint.WardId);
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name", complaint.AssignedWorkerId);
            return View(complaint);
        }

        // Practical 15: Update - GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
                return NotFound();

            ViewBag.Citizens = new SelectList(_context.Citizens, "Id", "Name", complaint.CitizenId);
            ViewBag.Wards = new SelectList(_context.Wards, "Id", "Name", complaint.WardId);
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name", complaint.AssignedWorkerId);
            return View(complaint);
        }

        // Practical 15: Update - POST
        // Practical 8: Async operation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,Priority,CitizenId,WardId,AssignedWorkerId,CreatedDate")] Complaint complaint)
        {
            if (id != complaint.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // If status is Resolved, set resolved date
                    if (complaint.Status == "Resolved" && !complaint.ResolvedDate.HasValue)
                        complaint.ResolvedDate = DateTime.Now;

                    _context.Update(complaint);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Complaint updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintExists(complaint.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Citizens = new SelectList(_context.Citizens, "Id", "Name", complaint.CitizenId);
            ViewBag.Wards = new SelectList(_context.Wards, "Id", "Name", complaint.WardId);
            ViewBag.Workers = new SelectList(_context.Workers, "Id", "Name", complaint.AssignedWorkerId);
            return View(complaint);
        }

        // Practical 15: Delete - GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var complaint = await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Ward)
                .Include(c => c.AssignedWorker)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (complaint == null)
                return NotFound();

            return View(complaint);
        }

        // Practical 15: Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Complaint deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        // Helper method for file upload
        private async Task SaveComplaintPhotoAsync(int complaintId, IFormFile photo)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "complaints");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{photo.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            var complaintPhoto = new ComplaintPhoto
            {
                ComplaintId = complaintId,
                FileName = photo.FileName,
                FilePath = $"/uploads/complaints/{uniqueFileName}",
                UploadedDate = DateTime.Now
            };

            _context.ComplaintPhotos.Add(complaintPhoto);
            await _context.SaveChangesAsync();
        }

        private bool ComplaintExists(int id)
        {
            return _context.Complaints.Any(e => e.Id == id);
        }
    }
}
