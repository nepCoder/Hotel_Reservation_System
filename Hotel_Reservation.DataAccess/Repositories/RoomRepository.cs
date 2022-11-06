using Hotel_Reservation.DataAccess.Context;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;
using HotelReservation.Entities;


namespace Hotel_Reservation.DataAccess.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly AppDbContext _context;
        public RoomRepository(AppDbContext context): base(context)
        {
            _context = context;
            dbSet = _context.Set<Room>();
        }

        
        public void Update(Room room)
        {
            dbSet.Update(room);

        }

        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
            
    }
}
