using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using GeoSupport_ms.Queries;
using GeoSupport_ms.Responses;

namespace GeoSupport_ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlagController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ColorQuery colorQuery; 

        public FlagController(AppDbContext context)
        {
            _context = context;
            colorQuery = new ColorQuery(_context);
        }

        // GET: api/Flag
        /// <summary>
        /// Gets a list of Flag elements
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flag>>> GetFlag()
        {
            return await _context.Flag.ToListAsync();
        }

        // GET: api/Flag/5
        /// <summary>
        /// Gets a specific Flag element given its Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<FlagColors>> GetFlag(int id)
        {
            var flag = await _context.Flag.FindAsync(id);

            if (flag == null)
            {
                return NotFound();
            }
            List<ColorOrder> colors = colorQuery.FindWhereId_flag(flag.Id_flag);

            return new FlagColors(flag, colors);
        }

        // PUT: api/Flag/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a specific Flag element given its Id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlag(int id, Flag flag)
        {
            if (id != flag.Id_flag)
            {
                return BadRequest();
            }

            _context.Entry(flag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlagExists(id))
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

        // POST: api/Flag
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Inserts a new Flag register in database
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Flag>> PostFlag(Flag flag)
        {
            _context.Flag.Add(flag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlag", new { id = flag.Id_flag }, flag);
        }

        // DELETE: api/Flag/5
        /// <summary>
        /// Deletes a specific Flag register given its Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flag>> DeleteFlag(int id)
        {
            var flag = await _context.Flag.FindAsync(id);
            if (flag == null)
            {
                return NotFound();
            }

            _context.Flag.Remove(flag);
            await _context.SaveChangesAsync();

            return flag;
        }

        private bool FlagExists(int id)
        {
            return _context.Flag.Any(e => e.Id_flag == id);
        }
    }
}
