using System.Linq.Expressions;

namespace Hotel_Reservation.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProp = null);
        //T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        bool Contains(T entity);
        
    }
}
