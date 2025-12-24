
using VillaBookingApp.Domain.Entities;

namespace VillaBookingApp.Application.Common.Interfaces
{
     public interface IVillaRepository : IRepository<Villa>
    {
        void Update(Villa villa);
    }
}
