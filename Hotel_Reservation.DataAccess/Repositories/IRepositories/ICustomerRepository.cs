using HotelReservation.Entities;

namespace Hotel_Reservation.DataAccess.Repositories.IRepositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        void Update(Customer customer);
        bool CustomerExists(int id);
    }
}
