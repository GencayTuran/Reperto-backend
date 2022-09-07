using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reperto.Data;
using Reperto.Models;

namespace Reperto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChordsController : Controller
    {
        private readonly RepertoDbContext _context;

        public ChordsController(RepertoDbContext context)
        {
            _context = context;
        }

        // GET: Chords
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Chords.ToListAsync());
        }

        // GET: Chords/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _context.Chords
                .FirstOrDefaultAsync(m => m.ChordId == id);
            if (chord == null)
            {
                return NotFound();
            }

            return Ok(chord);
        }

        // GET: Chords/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Chords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("ChordId,Name,Image")] Chord chord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chord);
        }

        // GET: Chords/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _context.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }
            return View(chord);
        }

        // POST: Chords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ChordId,Name,Image")] Chord chord)
        {
            if (id != chord.ChordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChordExists(chord.ChordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chord);
        }

        // GET: Chords/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _context.Chords
                .FirstOrDefaultAsync(m => m.ChordId == id);
            if (chord == null)
            {
                return NotFound();
            }

            return View(chord);
        }

        // POST: Chords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chord = await _context.Chords.FindAsync(id);
            _context.Chords.Remove(chord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChordExists(int id)
        {
            return _context.Chords.Any(e => e.ChordId == id);
        }
    }
}
