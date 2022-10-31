using Hotel_Reservation_System.Context;
using Hotel_Reservation_System.Models;
using Hotel_Reservation_System.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Hotel_Reservation_System.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context): base(context)
        {
            _context = context;
            dbSet = _context.Set<Customer>();
        }

        
        public void Update(Customer customer)
        {
            dbSet.Update(customer);

        }

        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        //This should be implemented in UnitofWork
        
    }
}
