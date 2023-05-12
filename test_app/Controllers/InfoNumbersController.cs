using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_app.Data;
using test_app.Model;

namespace test_apI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoNumbersController : ControllerBase
    {
        private readonly test_appContext _context;

        public InfoNumbersController(test_appContext context)
        {
            _context = context;
        }

        // GET: api/InfoNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoNumbers>>> GetInfoNumbers()
        {
          if (_context.InfoNumbers == null)
          {
              return NotFound();
          }
            return await _context.InfoNumbers.ToListAsync();
        }

        // GET: api/InfoNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoNumbers>> GetInfoNumbers(int id)
        {
          if (_context.InfoNumbers == null)
          {
              return NotFound();
          }
            var infoNumbers = await _context.InfoNumbers.FindAsync(id);

            if (infoNumbers == null)
            {
                return NotFound();
            }

            return infoNumbers;
        }

        // PUT: api/InfoNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoNumbers(int id, InfoNumbers infoNumbers)
        {
            if (id != infoNumbers.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoNumbersExists(id))
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

        // POST: api/InfoNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoNumbers>> PostInfoNumbers(InfoNumbers infoNumbers)
        {
          if (_context.InfoNumbers == null)
          {
              return Problem("Entity set 'test_appContext.InfoNumbers'  is null.");
          }
            _context.InfoNumbers.Add(infoNumbers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoNumbers", new { id = infoNumbers.Id }, infoNumbers);
        }

        // DELETE: api/InfoNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoNumbers(int id)
        {
            if (_context.InfoNumbers == null)
            {
                return NotFound();
            }
            var infoNumbers = await _context.InfoNumbers.FindAsync(id);
            if (infoNumbers == null)
            {
                return NotFound();
            }

            _context.InfoNumbers.Remove(infoNumbers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoNumbersExists(int id)
        {
            return (_context.InfoNumbers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
