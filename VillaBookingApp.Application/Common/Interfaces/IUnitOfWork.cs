

namespace VillaBookingApp.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IVillaRepository Villa { get; }
        IBookingRepository Bookings { get; }
        void Save();
    }
}
