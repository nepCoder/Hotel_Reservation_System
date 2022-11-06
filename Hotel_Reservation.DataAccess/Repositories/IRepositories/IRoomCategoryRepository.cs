using HotelReservation.Entities;

namespace Hotel_Reservation.DataAccess.Repositories.IRepositories
{
    public interface IRoomCategoryRepository : IRepository<RoomCategory>
    {
        void Update(RoomCategory category);
        bool CategoryExists(int id);
    }
}
