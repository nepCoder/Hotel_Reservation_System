using System.Linq.Expressions;

namespace Hotel_Reservation_System.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        //T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        
    }
}
