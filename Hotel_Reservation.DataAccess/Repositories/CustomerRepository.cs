using Hotel_Reservation.DataAccess.Context;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;
using HotelReservation.Entities;


namespace Hotel_Reservation.DataAccess.Repositories
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

        
    }
}
