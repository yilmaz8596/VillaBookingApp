

using Microsoft.EntityFrameworkCore;
using VillaBookingApp.Domain.Entities;

namespace VillaBookingApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Villa> Villas { get; set; }

        }
}
