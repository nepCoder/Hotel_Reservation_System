using Hotel_Reservation.DataAccess.Context;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;
using HotelReservation.Entities;


namespace Hotel_Reservation.DataAccess.Repositories
{
    public class RoomCategoryRepository : Repository<RoomCategory>, IRoomCategoryRepository
    {
        private readonly AppDbContext _context;
        public RoomCategoryRepository(AppDbContext context): base(context)
        {
            _context = context;
            dbSet = _context.Set<RoomCategory>();
        }

        
        public void Update(RoomCategory category)
        {
            dbSet.Update(category);

        }

        public bool CategoryExists(int id)
        {
            return _context.RoomCategories.Any(e => e.Id == id);
        }

        
    }
}
