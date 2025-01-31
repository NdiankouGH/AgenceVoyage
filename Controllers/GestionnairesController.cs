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
    public class GestionnairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestionnairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gestionnaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gestionnaires.ToListAsync());
        }

        // GET: Gestionnaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionnaire = await _context.Gestionnaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionnaire == null)
            {
                return NotFound();
            }

            return View(gestionnaire);
        }

        // GET: Gestionnaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,Password,NumTel,DateCreation")] Gestionnaire gestionnaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestionnaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestionnaire);
        }

        // GET: Gestionnaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionnaire = await _context.Gestionnaires.FindAsync(id);
            if (gestionnaire == null)
            {
                return NotFound();
            }
            return View(gestionnaire);
        }

        // POST: Gestionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,Password,NumTel,DateCreation")] Gestionnaire gestionnaire)
        {
            if (id != gestionnaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestionnaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestionnaireExists(gestionnaire.Id))
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
            return View(gestionnaire);
        }

        // GET: Gestionnaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionnaire = await _context.Gestionnaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionnaire == null)
            {
                return NotFound();
            }

            return View(gestionnaire);
        }

        // POST: Gestionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestionnaire = await _context.Gestionnaires.FindAsync(id);
            if (gestionnaire != null)
            {
                _context.Gestionnaires.Remove(gestionnaire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestionnaireExists(int id)
        {
            return _context.Gestionnaires.Any(e => e.Id == id);
        }
    }
}
