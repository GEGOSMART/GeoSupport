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

namespace GeoSupport_ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CountryQuery countryQuery;

        public ContinentController(AppDbContext context)
        {
            _context = context;
            countryQuery = new CountryQuery(_context);
        }

        // GET: api/Continent
        /// <summary>
        /// Gets a list of Continent elements
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Continent>>> GetContinent()
        {
            return await _context.Continent.ToListAsync();
        }

        // GET: api/Continent/5
        /// <summary>
        /// Gets a specific Continent element given its Id
        /// </summary>
        /// <response code="404">If there is not item whit that id</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Continent>> GetContinent(int id)
        {
            var continent = await _context.Continent.FindAsync(id);

            if (continent == null)
            {
                return NotFound();
            }
            continent.Countries = countryQuery.FindWhereIdContinent(continent.Id_continent);

            return continent;
        }

        // PUT: api/Continent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Updates a specific Continent element given its Id
        /// </summary>
        /// <response code="400">If given id not valid</response>
        /// <response code="404">When an error is producted updating db</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContinent(int id, Continent continent)
        {
            if (id != continent.Id_continent)
            {
                return BadRequest();
            }

            _context.Entry(continent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinentExists(id))
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

        // POST: api/Continent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Inserts a new Continent register in database
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Continent>> PostContinent(Continent continent)
        {
            _context.Continent.Add(continent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContinent", new { id = continent.Id_continent }, continent);
        }

        // DELETE: api/Continent/5
        /// <summary>
        /// Deletes a specific Continent register given its Id
        /// </summary>
        /// <response code="404">If there is not item whit that id</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Continent>> DeleteContinent(int id)
        {
            var continent = await _context.Continent.FindAsync(id);
            if (continent == null)
            {
                return NotFound();
            }

            _context.Continent.Remove(continent);
            await _context.SaveChangesAsync();

            return continent;
        }

        private bool ContinentExists(int id)
        {
            return _context.Continent.Any(e => e.Id_continent == id);
        }
    }
}
