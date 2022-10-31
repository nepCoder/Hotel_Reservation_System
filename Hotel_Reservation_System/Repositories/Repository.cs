using Hotel_Reservation_System.Context;
using Hotel_Reservation_System.Models;
using Hotel_Reservation_System.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Linq.Expressions;

namespace Hotel_Reservation_System.Repositories
{
    public class Repository<T>:IRepository<T> where T:class  
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
           dbSet.Add(entity);
           //use method from UnitOfWork to SaveChanges

        }

        

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        //public T GetById(int id)
        //{
            
        //}

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.FirstOrDefault(filter);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            //use method from UnitOfWork to SaveChanges

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);  
        }

        
    }
}
