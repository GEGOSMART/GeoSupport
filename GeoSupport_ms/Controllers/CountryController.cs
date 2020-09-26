using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using GeoSupport_ms.Util;
using GeoSupport_ms.Queries;

namespace GeoSupport_ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PlaceQuery placeQuery;
        private readonly FlagQuery flagQuery;

        public CountryController(AppDbContext context)
        {
            _context = context;
            placeQuery = new PlaceQuery(_context);
            flagQuery = new FlagQuery(_context);
        }

        // GET: api/Countrie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            return await _context.Country.ToListAsync();
        }
        [HttpGet("ContinentId/{id}")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries(int id)
        {
            return await _context.Country.Where(s => s.ContinentId_continent == id).ToListAsync();
        }

        // GET: api/Countrie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }
            Logger.Log("Entra");
            country.Places = placeQuery.FindWhereIdCountry(country.Id_country);
            country.Flag = flagQuery.FindWhereIdFlag(country.FlagId_flag);
            return country;
        }

        // PUT: api/Countrie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id_country)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countrie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Country.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id_country }, country);
        }

        // DELETE: api/Countrie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        private bool CountryExists(int id)
        {
            return _context.Country.Any(e => e.Id_country == id);
        }
    }
}
