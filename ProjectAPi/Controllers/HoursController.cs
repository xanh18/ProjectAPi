using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPi.Data;
using ProjectAPi.Models;

namespace ProjectAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoursController : ControllerBase
    {
        private readonly ProjectContext _context;

        public HoursController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Hours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hours>>> GetHours()
        {
          if (_context.Hours == null)
          {
              return NotFound();
          }
            return await _context.Hours.ToListAsync();
        }

        // GET: api/Hours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hours>> GetHours(int id)
        {
          if (_context.Hours == null)
          {
              return NotFound();
          }
            var hours = await _context.Hours.FindAsync(id);

            if (hours == null)
            {
                return NotFound();
            }

            return hours;
        }

        // PUT: api/Hours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/hours/verify/{id}")]
        public async Task<IActionResult> PutHours(int id, Hours hours)
        {
            if (id != hours.Id)
            {
                return BadRequest();
            }

            _context.Entry(hours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoursExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hours>> PostHours(Hours hours)
        {
          if (_context.Hours == null)
          {
              return Problem("Entity set 'ProjectContext.Hours'  is null.");
          }
            _context.Hours.Add(hours);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHours), new { id = hours.Id }, hours);
        }

        // DELETE: api/Hours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHours(int id)
        {
            if (_context.Hours == null)
            {
                return NotFound();
            }
            var hours = await _context.Hours.FindAsync(id);
            if (hours == null)
            {
                return NotFound();
            }

            _context.Hours.Remove(hours);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoursExists(int id)
        {
            return (_context.Hours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
