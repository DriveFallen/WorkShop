﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkShop.Data;
using WorkShop.Models;

namespace WorkShop.Controllers
{
    public class KitsController : Controller
    {
        private readonly WorkshopDbContext _context;

        public KitsController(WorkshopDbContext context)
        {
            _context = context;
        }

        // GET: Kits
        public async Task<IActionResult> Index()
        {
              return _context.Kits != null ? 
                          View(await _context.Kits.ToListAsync()) :
                          Problem("Entity set 'WorkshopDbContext.Kits'  is null.");
        }

        // GET: Kits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kits == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kit == null)
            {
                return NotFound();
            }

            return View(kit);
        }

        // GET: Kits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price,Photo")] Kit kit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kit);
        }

        // GET: Kits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kits == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits.FindAsync(id);
            if (kit == null)
            {
                return NotFound();
            }
            return View(kit);
        }

        // POST: Kits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Price,Photo")] Kit kit)
        {
            if (id != kit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitExists(kit.ID))
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
            return View(kit);
        }

        // GET: Kits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kits == null)
            {
                return NotFound();
            }

            var kit = await _context.Kits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kit == null)
            {
                return NotFound();
            }

            return View(kit);
        }

        // POST: Kits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kits == null)
            {
                return Problem("Entity set 'WorkshopDbContext.Kits'  is null.");
            }
            var kit = await _context.Kits.FindAsync(id);
            if (kit != null)
            {
                _context.Kits.Remove(kit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitExists(int id)
        {
          return (_context.Kits?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
