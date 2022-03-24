using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerAPI.Data;
using TrackerAPI.Models;

namespace TrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftingStatsController : ControllerBase
    {
        private readonly ExerciseContext _context;

        public LiftingStatsController(ExerciseContext context)
        {
            _context = context;
        }

        // GET: api/LiftingStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LiftingStat>>> GetLiftingStats()
        {
            return await _context.LiftingStats.ToListAsync();
        }

        // GET: api/LiftingStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LiftingStat>> GetLiftingStat(int id)
        {
            var liftingStat = await _context.LiftingStats.FindAsync(id);

            if (liftingStat == null)
            {
                return NotFound();
            }

            return liftingStat;
        }

        // PUT: api/LiftingStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiftingStat(int id, LiftingStat liftingStat)
        {
            if (id != liftingStat.LiftingStatId)
            {
                return BadRequest();
            }

            _context.Entry(liftingStat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiftingStatExists(id))
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

        // POST: api/LiftingStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LiftingStat>> PostLiftingStat(LiftingStat liftingStat)
        {
            _context.LiftingStats.Add(liftingStat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiftingStat", new { id = liftingStat.LiftingStatId }, liftingStat);
        }

        // DELETE: api/LiftingStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiftingStat(int id)
        {
            var liftingStat = await _context.LiftingStats.FindAsync(id);
            if (liftingStat == null)
            {
                return NotFound();
            }

            _context.LiftingStats.Remove(liftingStat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LiftingStatExists(int id)
        {
            return _context.LiftingStats.Any(e => e.LiftingStatId == id);
        }
    }
}
