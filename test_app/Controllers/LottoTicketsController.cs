using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_app.Data;
using test_app.Model;

namespace test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LottoTicketsController : ControllerBase
    {
        private readonly test_appContext _context;

        public LottoTicketsController(test_appContext context)
        {
            _context = context;
        }

        // GET: api/LottoTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LottoTickets>>> GetLottoTickets()
        {
          if (_context.LottoTickets == null)
          {
              return NotFound();
          }
            return await _context.LottoTickets.ToListAsync();
        }

        // GET: api/LottoTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LottoTickets>> GetLottoTickets(int id)
        {
          if (_context.LottoTickets == null)
          {
              return NotFound();
          }
            var lottoTickets = await _context.LottoTickets.FindAsync(id);

            if (lottoTickets == null)
            {
                return NotFound();
            }

            return lottoTickets;
        }

        // PUT: api/LottoTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLottoTickets(int id, LottoTickets lottoTickets)
        {
            if (id != lottoTickets.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(lottoTickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LottoTicketsExists(id))
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

        // POST: api/LottoTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LottoTickets>> PostLottoTickets(LottoTickets lottoTickets)
        {
          if (_context.LottoTickets == null)
          {
              return Problem("Entity set 'test_appContext.LottoTickets'  is null.");
          }
            _context.LottoTickets.Add(lottoTickets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLottoTickets", new { id = lottoTickets.TicketId }, lottoTickets);
        }

        // DELETE: api/LottoTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLottoTickets(int id)
        {
            if (_context.LottoTickets == null)
            {
                return NotFound();
            }
            var lottoTickets = await _context.LottoTickets.FindAsync(id);
            if (lottoTickets == null)
            {
                return NotFound();
            }

            _context.LottoTickets.Remove(lottoTickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LottoTicketsExists(int id)
        {
            return (_context.LottoTickets?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }
    }
}
