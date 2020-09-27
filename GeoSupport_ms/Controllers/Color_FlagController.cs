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
    public class Color_FlagController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Color_FlagController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Color_Flag
        /// <summary>
        /// Gets a list of Color_Flags elements
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color_Flag>>> GetColor_Flag()
        {
            return await _context.Color_Flag.ToListAsync();
        }

        // GET: api/Color_Flag/5
        /// <summary>
        /// Gets a specific Color_Flag element given its color_id (c_id) and flag_id (f_id)
        /// </summary>
        [HttpGet("{c_id}/{f_id}")]
        public async Task<ActionResult<Color_Flag>> GetColor_Flag(int c_id, int f_id)
        {
            var color_Flag = await _context.Color_Flag.FindAsync(c_id, f_id);

            if (color_Flag == null)
            {
                return NotFound();
            }

            return color_Flag;
        }

        // PUT: api/Color_Flag/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a specific Color_Flag element given its color_id (c_id) and flag_id (f_id)
        /// </summary>
        [HttpPut("{c_id}/{f_id}")]
        public async Task<IActionResult> PutColor_Flag(int c_id,int f_id, Color_Flag color_Flag)
        {
            if (c_id != color_Flag.Id_color|| f_id != color_Flag.Id_flag)
            {
                return BadRequest();
            }

            _context.Entry(color_Flag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Color_FlagExists(c_id,f_id))
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

        // POST: api/Color_Flag
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Inserts a new Color_Flag register in database
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Color_Flag>> PostColor_Flag(Color_Flag color_Flag)
        {
            _context.Color_Flag.Add(color_Flag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Color_FlagExists(color_Flag.Id_color,color_Flag.Id_flag))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetColor_Flag", new { id = color_Flag.Id_color }, color_Flag);
        }

        // DELETE: api/Color_Flag/5
        /// <summary>
        /// Deletes a specific Color_Flag element given its color_id (c_id) and flag_id (f_id)
        /// </summary>
        [HttpDelete("{c_id}/{f_id}")]
        public async Task<ActionResult<Color_Flag>> DeleteColor_Flag(int c_id, int f_id)
        {
            var color_Flag = await _context.Color_Flag.FindAsync(c_id, f_id);
            if (color_Flag == null)
            {
                return NotFound();
            }

            _context.Color_Flag.Remove(color_Flag);
            await _context.SaveChangesAsync();

            return color_Flag;
        }

        private bool Color_FlagExists(int c_id, int f_id)
        {
            return _context.Color_Flag.Any(e => e.Id_color == c_id) && _context.Color_Flag.Any(e => e.Id_flag == f_id);
        }
    }
}
