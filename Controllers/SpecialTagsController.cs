using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lunettes.Data;
using lunettes.Models;

namespace lunettes.Controllers
{
    public class SpecialTagsController : Controller
    {
        private readonly lunettesContext _context;

        public SpecialTagsController(lunettesContext context)
        {
            _context = context;
        }

        // GET: SpecialTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecialTags.ToListAsync());
        }

        // GET: SpecialTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _context.SpecialTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        // GET: SpecialTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SpecialTag")] SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialTags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        // GET: SpecialTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _context.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }
            return View(specialTags);
        }

        // POST: SpecialTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SpecialTag")] SpecialTags specialTags)
        {
            if (id != specialTags.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialTags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialTagsExists(specialTags.Id))
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
            return View(specialTags);
        }

        // GET: SpecialTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _context.SpecialTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        // POST: SpecialTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialTags = await _context.SpecialTags.FindAsync(id);
            if (specialTags != null)
            {
                _context.SpecialTags.Remove(specialTags);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialTagsExists(int id)
        {
            return _context.SpecialTags.Any(e => e.Id == id);
        }
    }
}
