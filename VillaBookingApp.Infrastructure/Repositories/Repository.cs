using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VillaBookingApp.Application.Common.Interfaces;
using VillaBookingApp.Infrastructure.Data;

namespace VillaBookingApp.Infrastructure.Repositories
{
    public class Repository<T>(AppDbContext dbContext) : IRepository<T> where T : class
    {
       private readonly AppDbContext _dbContext = dbContext;
       internal DbSet<T> dbSet = dbContext.Set<T>();

        public void Add(T villa)
        {
            dbSet.Add(villa);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault()!;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public void Remove(T villa)
        {
            dbSet.Remove(villa);
        }

        public void Update(T villa)
        {
            dbSet.Update(villa);
        }
    }
}
