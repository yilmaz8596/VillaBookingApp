
using System.Linq.Expressions;


namespace VillaBookingApp.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T villa);
        void Update(T villa);
        void Remove(T villa);
    }
}
