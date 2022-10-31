using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation_System.Context;
using Hotel_Reservation_System.Models;
using Hotel_Reservation_System.Repositories.IRepositories;

namespace Hotel_Reservation_System.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CustomersController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: Customers
        public IActionResult Index()
        {

            return View(_unit.Customer.GetAll());
        }

        // GET: Customers/Details/5
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

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        
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

        // GET: Customers/Edit/5
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

        // POST: Customers/Edit/5
        
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

        // GET: Customers/Delete/5
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

        // POST: Customers/Delete/5
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

        private bool CustomerExists(int id)
        {
          return _unit.Customer.CustomerExists(id);
        }
    }
}
