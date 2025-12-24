
using VillaBookingApp.Application.Common.Interfaces;
using VillaBookingApp.Infrastructure.Data;

namespace VillaBookingApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IVillaRepository Villa { get;private set; }

        public UnitOfWork( 
            AppDbContext context
            )
        {
            _context = context;
            Villa = new VillaRepository(_context);
        }

        public IBookingRepository Bookings => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
