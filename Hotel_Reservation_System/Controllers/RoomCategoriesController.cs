using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation.DataAccess.Context;
using HotelReservation.Entities;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;

namespace Hotel_Reservation_System.Controllers
{
    public class RoomCategoriesController : Controller
    {
        #region private fields
        private readonly IUnitOfWork _unit;
        #endregion

        #region constructor
        public RoomCategoriesController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        #endregion

        #region GET: RoomCategories
        public IActionResult Index()
        {
            return View(_unit.RoomCategory.GetAll());
        }

        #endregion

        #region GET: RoomCategories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _unit.RoomCategory == null)
            {
                return NotFound();
            }

            var roomCategory = _unit.RoomCategory
                .GetFirstOrDefault(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            return View(roomCategory);
        }

        #endregion

        #region GET: RoomCategories/Create
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST: RoomCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoryName,CategoryDescription")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                _unit.RoomCategory.Add(roomCategory);
                _unit.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(roomCategory);
        }

        #endregion

        #region GET: RoomCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _unit.RoomCategory == null)
            {
                return NotFound();
            }

            var roomCategory = _unit.RoomCategory.GetFirstOrDefault(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound();
            }
            return View(roomCategory);
        }
        #endregion

        #region POST: RoomCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CategoryName,CategoryDescription")] RoomCategory roomCategory)
        {
            if (id != roomCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unit.RoomCategory.Update(roomCategory);
                    _unit.Commit();
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
        #endregion

        #region GET: RoomCategories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _unit.RoomCategory == null)
            {
                return NotFound();
            }

            var roomCategory = _unit.RoomCategory.GetFirstOrDefault(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound(); 
            }

            return View(roomCategory);
        }
        #endregion

        #region POST: RoomCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_unit.RoomCategory == null)
            {
                return Problem("Entity set '_unit.RoomCategory'  is null.");
            }
            var roomCategory = _unit.RoomCategory.GetFirstOrDefault(m => m.Id == id);
            if (roomCategory != null)
            {
                _unit.RoomCategory.Remove(roomCategory);
            }

            _unit.Commit();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region RoomCategoryExists()
        private bool RoomCategoryExists(int id)
        {
            return _unit.RoomCategory.CategoryExists(id);
        }
        #endregion  
    }
}