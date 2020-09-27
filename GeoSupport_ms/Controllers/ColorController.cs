using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;

namespace GeoSupport_ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Color
        /// <summary>
        /// Gets a list of Color elements
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColor()
        {
            return await _context.Color.ToListAsync();
        }

        // GET: api/Color/5
        /// <summary>
        /// Gets a specific Color element given its Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            var color = await _context.Color.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }
            return color;
        }

        // PUT: api/Color/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a specific Color element given its Id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
        {
            if (id != color.Id_color)
            {
                return BadRequest();
            }

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Color
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Inserts a new Color register in database
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            _context.Color.Add(color);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new { id = color.Id_color }, color);
        }

        // DELETE: api/Color/5
        /// <summary>
        /// Deletes a specific Color register given its Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(int id)
        {
            var color = await _context.Color.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Color.Remove(color);
            await _context.SaveChangesAsync();

            return color;
        }

        private bool ColorExists(int id)
        {
            return _context.Color.Any(e => e.Id_color == id);
        }
    }
}
