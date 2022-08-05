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
    public class RepertoiresController : Controller
    {
        private readonly RepertoDbContext _context;

        public RepertoiresController(RepertoDbContext context)
        {
            _context = context;
        }

        // GET: Repertoires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repertoires.ToListAsync());
        }

        // GET: Repertoires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repertoire = await _context.Repertoires
                .FirstOrDefaultAsync(m => m.RepertoireId == id);
            if (repertoire == null)
            {
                return NotFound();
            }

            return View(repertoire);
        }

        // GET: Repertoires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repertoires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepertoireId")] Repertoire repertoire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repertoire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repertoire);
        }

        // GET: Repertoires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repertoire = await _context.Repertoires.FindAsync(id);
            if (repertoire == null)
            {
                return NotFound();
            }
            return View(repertoire);
        }

        // POST: Repertoires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepertoireId")] Repertoire repertoire)
        {
            if (id != repertoire.RepertoireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repertoire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepertoireExists(repertoire.RepertoireId))
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
            return View(repertoire);
        }

        // GET: Repertoires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repertoire = await _context.Repertoires
                .FirstOrDefaultAsync(m => m.RepertoireId == id);
            if (repertoire == null)
            {
                return NotFound();
            }

            return View(repertoire);
        }

        // POST: Repertoires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repertoire = await _context.Repertoires.FindAsync(id);
            _context.Repertoires.Remove(repertoire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepertoireExists(int id)
        {
            return _context.Repertoires.Any(e => e.RepertoireId == id);
        }
    }
}
