using Hotel_Reservation.DataAccess.Context;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;

namespace Hotel_Reservation.DataAccess.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customer = new CustomerRepository(_context);
        }

        public ICustomerRepository Customer{get; private set;}

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
