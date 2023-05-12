using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_app.Data;
using test_app.Model;

namespace test_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinningNumbersController : ControllerBase
    {
        private readonly test_appContext _context;

        public WinningNumbersController(test_appContext context)
        {
            _context = context;
        }

        // GET: api/WinningNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinningNumbers>>> GetWinningNumbers()
        {
          if (_context.WinningNumbers == null)
          {
              return NotFound();
          }
            return await _context.WinningNumbers.ToListAsync();
        }

        // GET: api/WinningNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WinningNumbers>> GetWinningNumbers(int id)
        {
          if (_context.WinningNumbers == null)
          {
              return NotFound();
          }
            var winningNumbers = await _context.WinningNumbers.FindAsync(id);

            if (winningNumbers == null)
            {
                return NotFound();
            }

            return winningNumbers;
        }

        // PUT: api/WinningNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinningNumbers(int id, WinningNumbers winningNumbers)
        {
            if (id != winningNumbers.WinningNumberId)
            {
                return BadRequest();
            }

            _context.Entry(winningNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinningNumbersExists(id))
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

        // POST: api/WinningNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WinningNumbers>> PostWinningNumbers(WinningNumbers winningNumbers)
        {
          if (_context.WinningNumbers == null)
          {
              return Problem("Entity set 'test_appContext.WinningNumbers'  is null.");
          }
            _context.WinningNumbers.Add(winningNumbers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWinningNumbers", new { id = winningNumbers.WinningNumberId }, winningNumbers);
        }

        // DELETE: api/WinningNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWinningNumbers(int id)
        {
            if (_context.WinningNumbers == null)
            {
                return NotFound();
            }
            var winningNumbers = await _context.WinningNumbers.FindAsync(id);
            if (winningNumbers == null)
            {
                return NotFound();
            }

            _context.WinningNumbers.Remove(winningNumbers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WinningNumbersExists(int id)
        {
            return (_context.WinningNumbers?.Any(e => e.WinningNumberId == id)).GetValueOrDefault();
        }
    }
}
