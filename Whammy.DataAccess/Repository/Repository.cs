using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;

namespace Whammy.DataAccess.Repository
{
    public class Repository<T> : IRepository.IRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;
        public DbSet<T> dbSet;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {

            dbSet.Add(entity);
        }


        public IEnumerable<T> GetAll(string? includeProps = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;


            //filter
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include
            if (includeProps != null)
            {
                foreach (var prop in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            //order
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProps != null)
            {
                foreach (var prop in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities.ToList());
        }
    }
}

