using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeethToEyeAPI.Models;

namespace TeethToEyeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UidsController : ControllerBase
    {
        private readonly TeethToEyeContext _context;

        public UidsController(TeethToEyeContext context)
        {
            _context = context;
        }

        // GET: api/Uids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uid>>> GetUid()
        {
          if (_context.Uid == null)
          {
              return NotFound();
          }
            return await _context.Uid.ToListAsync();
        }

        // GET: api/Uids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uid>> GetUid(string id)
        {
          if (_context.Uid == null)
          {
              return NotFound();
          }
            var uid = await _context.Uid.FindAsync(id);

            if (uid == null)
            {
                return NotFound();
            }

            return uid;
        }

        // PUT: api/Uids/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUid(string id, Uid uid)
        {
            if (id != uid.Uid1)
            {
                return BadRequest();
            }

            _context.Entry(uid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UidExists(id))
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

        // POST: api/Uids
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uid>> PostUid(Uid uid)
        {
          if (_context.Uid == null)
          {
              return Problem("Entity set 'TeethToEyeContext.Uid'  is null.");
          }
            _context.Uid.Add(uid);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UidExists(uid.Uid1))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUid", new { id = uid.Uid1 }, uid);
        }

        // DELETE: api/Uids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUid(string id)
        {
            if (_context.Uid == null)
            {
                return NotFound();
            }
            var uid = await _context.Uid.FindAsync(id);
            if (uid == null)
            {
                return NotFound();
            }

            _context.Uid.Remove(uid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UidExists(string id)
        {
            return (_context.Uid?.Any(e => e.Uid1 == id)).GetValueOrDefault();
        }
    }
}
