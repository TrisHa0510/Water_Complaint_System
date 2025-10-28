using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterComplaintSystem.Data;
using WaterComplaintSystem.Models;

namespace WaterComplaintSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Api/complaints
        [HttpGet("complaints")]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetComplaints()
        {
            return await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Ward)
                .Include(c => c.AssignedWorker)
                .ToListAsync();
        }

        // GET: api/Api/complaints/5
        [HttpGet("complaints/{id}")]
        public async Task<ActionResult<Complaint>> GetComplaint(int id)
        {
            var complaint = await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Ward)
                .Include(c => c.AssignedWorker)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (complaint == null)
                return NotFound();

            return complaint;
        }

        // POST: api/Api/complaints
        [HttpPost("complaints")]
        public async Task<ActionResult<Complaint>> CreateComplaint(Complaint complaint)
        {
            complaint.CreatedDate = DateTime.Now;
            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComplaint), new { id = complaint.Id }, complaint);
        }

        // PUT: api/Api/complaints/5
        [HttpPut("complaints/{id}")]
        public async Task<IActionResult> UpdateComplaint(int id, Complaint complaint)
        {
            if (id != complaint.Id)
                return BadRequest();

            _context.Entry(complaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Complaints.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Api/complaints/5
        [HttpDelete("complaints/{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
                return NotFound();

            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Api/wards
        [HttpGet("wards")]
        public async Task<ActionResult<IEnumerable<Ward>>> GetWards()
        {
            return await _context.Wards.ToListAsync();
        }
    }
}
