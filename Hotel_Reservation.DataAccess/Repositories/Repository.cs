using Hotel_Reservation.DataAccess.Context;
using Hotel_Reservation.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hotel_Reservation.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T:class  
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
        }

        public bool Contains(T entity)
        {
            return dbSet.Contains(entity);
        }

        public IEnumerable<T> GetAll(string? includeProp=null)
        {
            IQueryable<T> query = dbSet;
            if(includeProp != null)
            {
                foreach(var prop in includeProp.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

        //public T GetById(int id)
        //{
            
        //}

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProp != null)
            {
                foreach (var prop in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
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
