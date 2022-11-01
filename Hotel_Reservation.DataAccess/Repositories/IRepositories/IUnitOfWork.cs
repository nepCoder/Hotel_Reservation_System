namespace Hotel_Reservation_System.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        void Commit();
    }
}
