using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoOglasi.Data;
using AutoOglasi.Models;
using Microsoft.AspNetCore.Authorization;


namespace AutoOglasi.Controllers
{
    public class AutomobiliController : Controller
    {
        private readonly AppDbContext _context;

        public AutomobiliController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automobili.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobili
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Model,Godiste,ZapreminaMotora,Snaga,Gorivo,Karoserija,Opis,Cena,Kontakt")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automobil);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobili.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Model,Godiste,ZapreminaMotora,Snaga,Gorivo,Karoserija,Opis,Cena,Kontakt")] Automobil automobil)
        {
            if (id != automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.Id))
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
            return View(automobil);
        }

        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobili
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automobil = await _context.Automobili.FindAsync(id);
            if (automobil != null)
            {
                _context.Automobili.Remove(automobil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobili.Any(e => e.Id == id);
        }
    }
}
