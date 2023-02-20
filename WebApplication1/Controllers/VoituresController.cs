using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VoituresController : Controller
    {
        private readonly WebApplication1Context _context;

        public VoituresController(WebApplication1Context context)
        {
            _context = context;
        }









        // GET: Voitures
        public async Task<IActionResult> Index(string VoituresMarque, string SearchString)
        {
            {
                if (_context.Voitures == null)
                {
                    return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
                }
                // Use LINQ to get list of genres.
                IQueryable<string> genreQuery = from m in _context.Voitures
                                                orderby m.Marque
                                                select m.Marque;
                var voiture = from m in _context.Voitures
                              select m;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    voiture = voiture.Where(s => s.Marque!.Contains(SearchString));
                }

                if (!string.IsNullOrEmpty(VoituresMarque))
                {
                    voiture = voiture.Where(x => x.Marque == VoituresMarque);
                }
                var searshvoitureVM = new SearshVoiture
                {
                    Marque = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Voitures = await voiture.ToListAsync()
                };

                return View(await _context.Voitures.ToListAsync());

            }
        }
        
        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voitures = await _context.Voitures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voitures == null)
            {
                return NotFound();
            }

            return View(voitures);
        }

        // GET: Voitures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Marque,Prix,DateFabrication,Rating")] Voitures voitures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voitures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voitures);
        }

        // GET: Voitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voitures = await _context.Voitures.FindAsync(id);
            if (voitures == null)
            {
                return NotFound();
            }
            return View(voitures);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Marque,Prix,DateFabrication,Rating")] Voitures voitures)
        {
            if (id != voitures.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voitures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoituresExists(voitures.Id))
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
            return View(voitures);
        }

        // GET: Voitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voitures = await _context.Voitures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voitures == null)
            {
                return NotFound();
            }

            return View(voitures);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voitures == null)
            {
                return Problem("Entity set 'WebApplication1Context.Voitures'  is null.");
            }
            var voitures = await _context.Voitures.FindAsync(id);
            if (voitures != null)
            {
                _context.Voitures.Remove(voitures);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoituresExists(int id)
        {
            return _context.Voitures.Any(e => e.Id == id);
        }
    }// GET: Movies

}