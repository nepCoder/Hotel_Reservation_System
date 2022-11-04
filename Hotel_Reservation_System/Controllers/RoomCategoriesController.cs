using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation_System.Context;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Controllers
{
    public class RoomCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public RoomCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RoomCategories
        public async Task<IActionResult> Index()
        {
              return View(await _context.RoomCategories.ToListAsync());
        }

        // GET: RoomCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomCategories == null)
            {
                return NotFound();
            }

            var roomCategory = await _context.RoomCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            return View(roomCategory);
        }

        // GET: RoomCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,CategoryDescription")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomCategory);
        }

        // GET: RoomCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomCategories == null)
            {
                return NotFound();
            }

            var roomCategory = await _context.RoomCategories.FindAsync(id);
            if (roomCategory == null)
            {
                return NotFound();
            }
            return View(roomCategory);
        }

        // POST: RoomCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,CategoryDescription")] RoomCategory roomCategory)
        {
            if (id != roomCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomCategoryExists(roomCategory.Id))
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
            return View(roomCategory);
        }

        // GET: RoomCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomCategories == null)
            {
                return NotFound();
            }

            var roomCategory = await _context.RoomCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            return View(roomCategory);
        }

        // POST: RoomCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomCategories == null)
            {
                return Problem("Entity set 'AppDbContext.RoomCategories'  is null.");
            }
            var roomCategory = await _context.RoomCategories.FindAsync(id);
            if (roomCategory != null)
            {
                _context.RoomCategories.Remove(roomCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomCategoryExists(int id)
        {
          return _context.RoomCategories.Any(e => e.Id == id);
        }
    }
}
