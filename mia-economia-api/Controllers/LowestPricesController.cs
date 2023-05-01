using miaEconomiaApi.Context;
using miaEconomiaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace miaEconomiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LowestPricesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LowestPricesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LowestPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LowestPrice>>> GetLowestPrices()
        {
            if (_context.LowestPrices == null)
            {
                return NotFound();
            }

            return await _context.LowestPrices.ToListAsync();
        }

        // GET: api/LowestPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LowestPrice>> GetLowestPrice(int id)
        {
            if (_context.LowestPrices == null)
            {
                return NotFound();
            }

            var lowestPrice = await _context.LowestPrices.FindAsync(id);

            if (lowestPrice == null)
            {
                return NotFound();
            }

            return lowestPrice;
        }

        // PUT: api/LowestPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLowestPrice(int id, LowestPrice lowestPrice)
        {
            if (id != lowestPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(lowestPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LowestPriceExists(id))
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

        // POST: api/LowestPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LowestPrice>> PostLowestPrice(LowestPrice lowestPrice)
        {
            if (_context.LowestPrices == null)
            {
                return Problem("Entity set 'AppDbContext.LowestPrices'  is null.");
            }
            _context.LowestPrices.Add(lowestPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLowestPrice", new { id = lowestPrice.Id }, lowestPrice);
        }

        // DELETE: api/LowestPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLowestPrice(int id)
        {
            if (_context.LowestPrices == null)
            {
                return NotFound();
            }

            var lowestPrice = await _context.LowestPrices.FindAsync(id);
            if (lowestPrice == null)
            {
                return NotFound();
            }

            _context.LowestPrices.Remove(lowestPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LowestPriceExists(int id)
        {
            return (_context.LowestPrices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
