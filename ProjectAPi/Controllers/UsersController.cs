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
    public class UsersController : ControllerBase
    {
        private readonly ProjectContext _context;

        public UsersController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet("/api/users")]
        public ActionResult Users([FromQuery]Users users)
        {

            var login = _context.Users.FirstOrDefault(u => u.UserName == users.UserName && u.Password == users.Password);
           
            if (login == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(login);
            }
         
        }

        // POST: api/Hours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/users/register")]
        public async Task<ActionResult<Users>> PostHours([FromBody]Users users)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ProjectContext.Hours'  is null.");
            }
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Users), new { id = users.Id }, users);
        }

    }
}
