using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberpunkAPI.Models;

namespace CyberpunkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly cyberpunkContext _context;

        public StatsController(cyberpunkContext context)
        {
            _context = context;
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stats>>> GetStats()
        {
            return await _context.Stats.ToListAsync();
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stats>> GetStats(int id)
        {
            var stats = await _context.Stats.FindAsync(id);

            if (stats == null)
            {
                return NotFound();
            }

            return stats;
        }

        // PUT: api/Stats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStats(int id, Stats stats)
        {
            if (id != stats.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(stats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatsExists(id))
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

        // POST: api/Stats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stats>> PostStats(Stats stats)
        {
            _context.Stats.Add(stats);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatsExists(stats.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStats", new { id = stats.PlayerId }, stats);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStats(int id)
        {
            var stats = await _context.Stats.FindAsync(id);
            if (stats == null)
            {
                return NotFound();
            }

            _context.Stats.Remove(stats);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatsExists(int id)
        {
            return _context.Stats.Any(e => e.PlayerId == id);
        }
    }
}
