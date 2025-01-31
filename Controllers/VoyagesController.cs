using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agence_voyage.Models;

namespace AgenceVoyage.Controllers
{
    public class VoyagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoyagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voyages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Voyages.Include(v => v.Chauffeur).Include(v => v.Flotte);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Voyages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages
                .Include(v => v.Chauffeur)
                .Include(v => v.Flotte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voyage == null)
            {
                return NotFound();
            }

            return View(voyage);
        }

        // GET: Voyages/Create
        public IActionResult Create()
        {
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeurs, "Id", "Nom");
            ViewData["FlotteId"] = new SelectList(_context.Flottes, "Id", "Matricule");
            return View();
        }

        // POST: Voyages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DateDepart,DateRetour,Prix,ChauffeurId,FlotteId")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voyage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeurs, "Id", "Nom", voyage.ChauffeurId);
            ViewData["FlotteId"] = new SelectList(_context.Flottes, "Id", "Matricule", voyage.FlotteId);
            return View(voyage);
        }

        // GET: Voyages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage == null)
            {
                return NotFound();
            }
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeurs, "Id", "Nom", voyage.ChauffeurId);
            ViewData["FlotteId"] = new SelectList(_context.Flottes, "Id", "Matricule", voyage.FlotteId);
            return View(voyage);
        }

        // POST: Voyages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,DateDepart,DateRetour,Prix,ChauffeurId,FlotteId")] Voyage voyage)
        {
            if (id != voyage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voyage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoyageExists(voyage.Id))
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
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeurs, "Id", "Nom", voyage.ChauffeurId);
            ViewData["FlotteId"] = new SelectList(_context.Flottes, "Id", "Matricule", voyage.FlotteId);
            return View(voyage);
        }

        // GET: Voyages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyages
                .Include(v => v.Chauffeur)
                .Include(v => v.Flotte)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voyage == null)
            {
                return NotFound();
            }

            return View(voyage);
        }

        // POST: Voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage != null)
            {
                _context.Voyages.Remove(voyage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoyageExists(int id)
        {
            return _context.Voyages.Any(e => e.Id == id);
        }
    }
}
