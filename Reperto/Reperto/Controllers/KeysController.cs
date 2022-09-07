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
    public class KeysController : ControllerBase
    {
        private readonly RepertoDbContext _context;
        public KeysController(RepertoDbContext context)
        {
            _context = context;
        }

        // GET: api/<KeysController>
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Keys.ToListAsync());
        }

        // GET api/<KeysController>/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await _context.Keys.FirstOrDefaultAsync(k => k.KeyId == id));
        }
    }
}
