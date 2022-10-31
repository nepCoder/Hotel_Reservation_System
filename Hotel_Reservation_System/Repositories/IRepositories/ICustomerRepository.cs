using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Repositories.IRepositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        void Update(Customer customer);
        bool CustomerExists(int id);
    }
}
