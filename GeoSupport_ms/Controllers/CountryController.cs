using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeoSupport_ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly AppDbContext context;
        public CountryController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return context.Country.ToList();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            var country = context.Country.FirstOrDefault(p => p.Id_country == id);
            return country;
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
