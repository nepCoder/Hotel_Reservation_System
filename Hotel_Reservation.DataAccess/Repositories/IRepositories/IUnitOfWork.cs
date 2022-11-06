using HotelReservation.Entities;

namespace Hotel_Reservation.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IRoomRepository Room { get; }
        ICustomerRepository Customer { get; }
        IRoomCategoryRepository RoomCategory { get; }


        void Commit();
    }
}
