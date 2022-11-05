namespace Hotel_Reservation.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        void Commit();
    }
}
