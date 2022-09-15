using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reperto.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reperto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsInRepertoiresController : ControllerBase
    {
        private readonly RepertoDbContext _context;
        public SongsInRepertoiresController(RepertoDbContext context)
        {
            _context = context;
        }
        // GET: api/<SongsInRepertoiresController>
        [HttpGet]
        [Route("index")]
        public async Task<IActionResult> Index()
            =>  Ok(await _context.SongInRepertoires
                .ToListAsync());

        // GET api/<SongsInRepertoiresController>/5
        //relevant?
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SongsInRepertoiresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SongsInRepertoiresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsInRepertoiresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
