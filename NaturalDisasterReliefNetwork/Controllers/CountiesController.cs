using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturalDisasterReliefNetwork.Models;

namespace NaturalDisasterReliefNetwork.Controllers
{
    public class CountiesController : Controller
    {
        private readonly DataContext _context;

        public CountiesController(DataContext context)
        {
            _context = context;
        }

        // GET: Counties
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Counties.Include(c => c.City);
            return View(await dataContext.ToListAsync());
        }

        // GET: Counties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Counties == null)
            {
                return NotFound();
            }

            var counties = await _context.Counties
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counties == null)
            {
                return NotFound();
            }

            return View(counties);
        }

        // GET: Counties/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            return View();
        }

        // POST: Counties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,County,CityId")] Counties counties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", counties.CityId);
            return View(counties);
        }

        // GET: Counties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Counties == null)
            {
                return NotFound();
            }

            var counties = await _context.Counties.FindAsync(id);
            if (counties == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", counties.CityId);
            return View(counties);
        }

        // POST: Counties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,County,CityId")] Counties counties)
        {
            if (id != counties.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountiesExists(counties.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", counties.CityId);
            return View(counties);
        }

        // GET: Counties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Counties == null)
            {
                return NotFound();
            }

            var counties = await _context.Counties
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (counties == null)
            {
                return NotFound();
            }

            return View(counties);
        }

        // POST: Counties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Counties == null)
            {
                return Problem("Entity set 'DataContext.Counties'  is null.");
            }
            var counties = await _context.Counties.FindAsync(id);
            if (counties != null)
            {
                _context.Counties.Remove(counties);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountiesExists(int? id)
        {
          return (_context.Counties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
