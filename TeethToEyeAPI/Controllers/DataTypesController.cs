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
    public class DataTypesController : ControllerBase
    {
        private readonly TeethToEyeContext _context;

        public DataTypesController(TeethToEyeContext context)
        {
            _context = context;
        }

        // GET: api/DataTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataType>>> GetDataType()
        {
          if (_context.DataType == null)
          {
              return NotFound();
          }
            return await _context.DataType.ToListAsync();
        }

        // GET: api/DataTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataType>> GetDataType(string id)
        {
          if (_context.DataType == null)
          {
              return NotFound();
          }
            var dataType = await _context.DataType.FindAsync(id);

            if (dataType == null)
            {
                return NotFound();
            }

            return dataType;
        }

        // PUT: api/DataTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataType(string id, DataType dataType)
        {
            if (id != dataType.DataTypeName)
            {
                return BadRequest();
            }

            _context.Entry(dataType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataTypeExists(id))
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

        // POST: api/DataTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataType>> PostDataType(DataType dataType)
        {
          if (_context.DataType == null)
          {
              return Problem("Entity set 'TeethToEyeContext.DataType'  is null.");
          }
            _context.DataType.Add(dataType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DataTypeExists(dataType.DataTypeName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDataType", new { id = dataType.DataTypeName }, dataType);
        }

        // DELETE: api/DataTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataType(string id)
        {
            if (_context.DataType == null)
            {
                return NotFound();
            }
            var dataType = await _context.DataType.FindAsync(id);
            if (dataType == null)
            {
                return NotFound();
            }

            _context.DataType.Remove(dataType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataTypeExists(string id)
        {
            return (_context.DataType?.Any(e => e.DataTypeName == id)).GetValueOrDefault();
        }
    }
}
