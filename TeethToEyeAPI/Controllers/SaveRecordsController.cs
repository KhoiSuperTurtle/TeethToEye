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
    public class SaveRecordsController : ControllerBase
    {
        private readonly TeethToEyeContext _context;

        public SaveRecordsController(TeethToEyeContext context)
        {
            _context = context;
        }

        // GET: api/SaveRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaveRecord>>> GetSaveRecord()
        {
          if (_context.SaveRecord == null)
          {
              return NotFound();
          }
            return await _context.SaveRecord.ToListAsync();
        }

        // GET: api/SaveRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaveRecord>> GetSaveRecord(int id)
        {
          if (_context.SaveRecord == null)
          {
              return NotFound();
          }
            var saveRecord = await _context.SaveRecord.FindAsync(id);

            if (saveRecord == null)
            {
                return NotFound();
            }

            return saveRecord;
        }

        // PUT: api/SaveRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaveRecord(int id, SaveRecord saveRecord)
        {
            if (id != saveRecord.IdSaveRecord)
            {
                return BadRequest();
            }

            _context.Entry(saveRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaveRecordExists(id))
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

        // POST: api/SaveRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaveRecord>> PostSaveRecord(SaveRecord saveRecord)
        {
          if (_context.SaveRecord == null)
          {
              return Problem("Entity set 'TeethToEyeContext.SaveRecord'  is null.");
          }
            _context.SaveRecord.Add(saveRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaveRecord", new { id = saveRecord.IdSaveRecord }, saveRecord);
        }

        // DELETE: api/SaveRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaveRecord(int id)
        {
            if (_context.SaveRecord == null)
            {
                return NotFound();
            }
            var saveRecord = await _context.SaveRecord.FindAsync(id);
            if (saveRecord == null)
            {
                return NotFound();
            }

            _context.SaveRecord.Remove(saveRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaveRecordExists(int id)
        {
            return (_context.SaveRecord?.Any(e => e.IdSaveRecord == id)).GetValueOrDefault();
        }
    }
}
