
using Microsoft.AspNetCore.Identity;

namespace VillaBookingApp.Domain.Entities
{
    public class AppUser : IdentityUser 
    {
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
