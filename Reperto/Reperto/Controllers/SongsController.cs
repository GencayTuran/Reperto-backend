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
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : Controller
    {
        private readonly RepertoDbContext _context;

        public SongsController(RepertoDbContext context)
        {
            _context = context;
        }

        // GET: Songs
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var repertoDbContext = _context.Songs.Include(s => s.Repertoire).Include(s => s.Key).ToListAsync();
            return Ok(await repertoDbContext);
        }

        // GET: Songs/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Repertoire)
                .Include(s => s.Key)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // GET: Songs/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewData["RepertoireId"] = new SelectList(_context.Repertoires, "RepertoireId", "RepertoireId");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("SongId,Title,Band,Lyrics,Mood,RepertoireId")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepertoireId"] = new SelectList(_context.Repertoires, "RepertoireId", "RepertoireId", song.RepertoireId);
            return View(song);
        }

        // GET: Songs/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["RepertoireId"] = new SelectList(_context.Repertoires, "RepertoireId", "RepertoireId", song.RepertoireId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,Title,Band,Lyrics,Mood,RepertoireId")] Song song)
        {
            if (id != song.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongId))
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
            ViewData["RepertoireId"] = new SelectList(_context.Repertoires, "RepertoireId", "RepertoireId", song.RepertoireId);
            return View(song);
        }

        // GET: Songs/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Repertoire)
                .Include(s => s.Key)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}
