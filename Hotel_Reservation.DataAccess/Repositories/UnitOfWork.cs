using Hotel_Reservation.DataAccess.Context;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;
using HotelReservation.Entities;

namespace Hotel_Reservation.DataAccess.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customer = new CustomerRepository(_context);
            RoomCategory = new RoomCategoryRepository(_context);
            Room = new RoomRepository(_context);
        }

        public ICustomerRepository Customer{get; private set;}
        public IRoomCategoryRepository RoomCategory { get; private set;}

        public IRoomRepository Room { get; private set;}

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
