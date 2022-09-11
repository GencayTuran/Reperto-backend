using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reperto.Data;
using Reperto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reperto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChordImagesController : ControllerBase
    {
        private readonly RepertoDbContext _context;
        public ChordImagesController(RepertoDbContext context)
        {
            _context = context;
        }

        // GET: api/<ChordImagesController>
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            //TODO: linq string match names (not id)
            return Ok(await _context.ChordImages.Include(c => c.Chord).ToListAsync());
        }

        // GET api/<ChordImagesController>/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chordImage = await _context.ChordImages
                .FirstOrDefaultAsync(m => m.ChordImageId == id);
            if (chordImage == null)
            {
                return NotFound();
            }

            return Ok(chordImage);
        }


        // POST api/<ChordImagesController>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            //TODO: model binding
            var chordImage = new ChordImage { ChordName = "", ImageData = "" };
            _context.Add(chordImage);
            await _context.SaveChangesAsync();
            return Ok(chordImage);
        }

        // PUT api/<ChordImagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChordImagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}