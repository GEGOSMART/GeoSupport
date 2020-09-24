using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeoSupport_ms.Controllers
{
    [Route("")]
    [ApiController]
    public class Default : ControllerBase
    {
        // GET: api/<Default>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "WELCOME TO SERVER" };
        }

        // GET api/<Default>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Default>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Default>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Default>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
