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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color_Flag>>> GetColor_Flag()
        {
            return await _context.Color_Flag.ToListAsync();
        }

        // GET: api/Color_Flag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color_Flag>> GetColor_Flag(int id)
        {
            var color_Flag = await _context.Color_Flag.FindAsync(id);

            if (color_Flag == null)
            {
                return NotFound();
            }

            return color_Flag;
        }

        // PUT: api/Color_Flag/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor_Flag(int id, Color_Flag color_Flag)
        {
            if (id != color_Flag.Id_color)
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
                if (!Color_FlagExists(id))
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
                if (Color_FlagExists(color_Flag.Id_color))
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color_Flag>> DeleteColor_Flag(int id)
        {
            var color_Flag = await _context.Color_Flag.FindAsync(id);
            if (color_Flag == null)
            {
                return NotFound();
            }

            _context.Color_Flag.Remove(color_Flag);
            await _context.SaveChangesAsync();

            return color_Flag;
        }

        private bool Color_FlagExists(int id)
        {
            return _context.Color_Flag.Any(e => e.Id_color == id);
        }
    }
}
