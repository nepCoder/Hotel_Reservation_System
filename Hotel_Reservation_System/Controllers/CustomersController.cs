using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservation.Entities;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;

namespace Hotel_Reservation_System.Controllers
{
    public class CustomersController : Controller
    {
        #region private fields
        private readonly IUnitOfWork _unit;
        #endregion

        #region Constructor
        public CustomersController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        #endregion

        #region GET:Customers
        public IActionResult Index()
        {

            return View(_unit.Customer.GetAll());
        }
        #endregion

        #region GET: Customers/Details/5
        public IActionResult Details(int id)
        {
            if (_unit.Customer == null)
            {
                return NotFound();
            }

            var customer = _unit.Customer.GetFirstOrDefault(x => x.Id == id);
                
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        #endregion

        #region GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FullName,Address,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customer.Add(customer);
                _unit.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        #endregion

        #region GET: Customers/Edit/5
        public IActionResult Edit(int id)
        {
            if (_unit.Customer == null)
            {
                return NotFound();
            }

            var customer = _unit.Customer.GetFirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        #endregion
                
        #region POST: Customers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FullName,Address,Phone")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unit.Customer.Update(customer);
                    _unit.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }
        #endregion
                
        #region GET: Customers/Delete/5
        public IActionResult Delete(int id)
        {
            if (_unit.Customer == null)
            {
                return NotFound();
            }

            var customer = _unit.Customer.GetFirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        #endregion

        #region POST: Customers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_unit.Customer == null)
            {
                return Problem("Entity set 'AppDbContext.Customers'  is null.");
            }
            var customer = _unit.Customer.GetFirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                _unit.Customer.Remove(customer);
            }

            _unit.Commit();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region CustomerExists(id)
        private bool CustomerExists(int id)
        {
          return _unit.Customer.CustomerExists(id);
        }
        #endregion
    }
}
