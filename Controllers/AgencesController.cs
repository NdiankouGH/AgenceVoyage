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
    public class AgencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Agences.Include(a => a.Gestionnaire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Agences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agence = await _context.Agences
                .Include(a => a.Gestionnaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agence == null)
            {
                return NotFound();
            }

            return View(agence);
        }

        // GET: Agences/Create
        public IActionResult Create()
        {
            ViewData["GestionnaireId"] = new SelectList(_context.Gestionnaires, "Id", "Email");
            return View();
        }

        // POST: Agences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adresse,Latitude,Longitude,RCCM,Ninea,Notes,GestionnaireId")] Agence agence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GestionnaireId"] = new SelectList(_context.Gestionnaires, "Id", "Email", agence.GestionnaireId);
            return View(agence);
        }

        // GET: Agences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agence = await _context.Agences.FindAsync(id);
            if (agence == null)
            {
                return NotFound();
            }
            ViewData["GestionnaireId"] = new SelectList(_context.Gestionnaires, "Id", "Email", agence.GestionnaireId);
            return View(agence);
        }

        // POST: Agences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adresse,Latitude,Longitude,RCCM,Ninea,Notes,GestionnaireId")] Agence agence)
        {
            if (id != agence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenceExists(agence.Id))
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
            ViewData["GestionnaireId"] = new SelectList(_context.Gestionnaires, "Id", "Email", agence.GestionnaireId);
            return View(agence);
        }

        // GET: Agences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agence = await _context.Agences
                .Include(a => a.Gestionnaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agence == null)
            {
                return NotFound();
            }

            return View(agence);
        }

        // POST: Agences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agence = await _context.Agences.FindAsync(id);
            if (agence != null)
            {
                _context.Agences.Remove(agence);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenceExists(int id)
        {
            return _context.Agences.Any(e => e.Id == id);
        }
    }
}
