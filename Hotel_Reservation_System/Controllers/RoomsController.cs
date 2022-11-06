using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation.DataAccess.Context;
using HotelReservation.Entities;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;

namespace Hotel_Reservation_System.Controllers
{
    public class RoomsController : Controller
    {
        #region private fields
        private readonly IUnitOfWork _unit;
        #endregion

        #region contructor
        public RoomsController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        #endregion

        #region GET: Rooms
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region GET: Rooms/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _unit.Room == null)
            {
                return NotFound();
            }

            var room = _unit.Room.GetFirstOrDefault(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
        #endregion

        #region GET: Rooms/Create
        public IActionResult Create()
        {
            
            IEnumerable<RoomCategory> roomCategoryList = _unit.RoomCategory.GetAll();

            /*
             * Initializes a new instance of the SelectList class by using 
             * the specified items for the list, 
             * the data value field, 
             * and the data text field.
             */

            ViewData["RoomCategoryId"] = new SelectList(roomCategoryList, "Id", "CategoryName");
            return View();
        }
        #endregion

        #region POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,RoomName,RoomDescription,RoomCategoryId,Status,Cost")] Room room)
        {
            if (ModelState.IsValid)
            {
                _unit.Room.Add(room);
                _unit.Commit();
                return RedirectToAction(nameof(Index));
            }

            /*
             * new SelectList(IEnumerable, string, string, object)
             * Initializes a new instance of the SelectList class by using 
             * the specified items for the list, 
             * the data value field, 
             * the data text field, and 
             * a selected value.
             */
            ViewData["RoomCategoryId"] = new SelectList(_unit.Room.GetAll(), "Id", "CategoryName", room.RoomCategoryId);
            return View(room);
        }
        #endregion

        #region GET: Rooms/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _unit.Room == null)
            {
                return NotFound();
            }

            var room = _unit.Room.GetFirstOrDefault(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> categoryList = _unit.RoomCategory.GetAll().Select(
                m => new SelectListItem
                {
                   Text = m.CategoryName,
                   Value = m.Id.ToString()
                });


            ViewBag.RoomCategory = categoryList;
            return View(room);
        }
        #endregion

        #region POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,RoomName,RoomDescription,RoomCategoryId,Status,Cost")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unit.Room.Update(room);
                    _unit.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            ViewData["RoomCategoryId"] = new SelectList(_unit.RoomCategory.GetAll(), "Id", "CategoryName", room.RoomCategoryId);
            return View(room);
        }
        #endregion

        #region GET: Rooms/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _unit.Room == null)
            {
                return NotFound();
            }

            var room = _unit.Room.GetFirstOrDefault(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
        #endregion

        #region POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_unit.Room == null)
            {
                return Problem("Entity set '_unit.Room'  is null.");
            }
            var room = _unit.Room.GetFirstOrDefault(m => m.Id == id);
            if (room != null)
            {
                _unit.Room.Remove(room);
            }

            _unit.Commit();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region RoomExists(id);
        private bool RoomExists(int id)
        {
            return _unit.Room.Contains(_unit.Room.GetFirstOrDefault(m => m.Id == id));
        }
        #endregion


        #region API Calls
        /// <summary>
        /// Rooms/GetAll
        /// </summary>
        /// <returns>json object of RoomList</returns>
        public IActionResult GetAll()
        {
            IEnumerable<Room> roomList = _unit.Room.GetAll(includeProp:"RoomCategory");
            return Json(new { data = roomList });
        }

        #endregion
    }

}