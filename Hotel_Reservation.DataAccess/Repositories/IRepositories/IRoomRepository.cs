using HotelReservation.Entities;

namespace Hotel_Reservation.DataAccess.Repositories.IRepositories
{
    public interface IRoomRepository:IRepository<Room>
    {
        void Update(Room room);
    }
}
