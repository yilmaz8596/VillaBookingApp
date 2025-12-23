using Microsoft.EntityFrameworkCore;
using VillaBookingApp.Infrastructure.Data;
using VillaBookingApp.Domain.Entities;

namespace VillaBookingApp.Infrastructure.Seeder
{
    public class Seeder(AppDbContext dbContext)
    {
        public async Task Seed()
        {
            if (await dbContext.Villas.AnyAsync())
            {
                return; // Data already seeded
            }

            List<Villa> villas = new()
            {
                new Villa
                {
                    Name = "Futuristic City Villa",
                    Description = "Ultra-modern architectural masterpiece with futuristic design. Experience cutting-edge technology and stunning city views.",
                    Price = 2500,
                    Sqft = 5500,
                    Occupancy = 10,
                    ImageUrl = "/assets/futuristic-city-architecture.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Contemporary Pool Villa",
                    Description = "Spectacular contemporary design with luxury pool. Perfect blend of digital art aesthetics and modern comfort.",
                    Price = 2000,
                    Sqft = 4800,
                    Occupancy = 8,
                    ImageUrl = "/assets/luxury-pool-villa-spectacular-contemporary-design-digital-art-real-estate-home-house-property-ge.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Ocean Terrace Paradise",
                    Description = "Luxury terrace with breathtaking ocean views. Elegant outdoor living spaces with spectacular coastal panorama.",
                    Price = 1800,
                    Sqft = 4200,
                    Occupancy = 7,
                    ImageUrl = "/assets/luxury-terrace-with-ocean-view.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Lakeside Luxury Retreat",
                    Description = "Stunning villa situated by a serene lake. Tranquil waterfront setting with premium amenities and natural beauty.",
                    Price = 1500,
                    Sqft = 3800,
                    Occupancy = 6,
                    ImageUrl = "/assets/luxury-villa-by-lake.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Pool Terrace Escape",
                    Description = "Luxurious terrace villa with private pool and balcony. Panoramic views and sophisticated outdoor entertainment areas.",
                    Price = 1700,
                    Sqft = 4000,
                    Occupancy = 8,
                    ImageUrl = "/assets/luxury-villa-terrace-with-pool-balcony.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Oceanfront Luxury Villa",
                    Description = "Premium villa with unobstructed ocean views. Direct beach access and world-class facilities for the ultimate coastal experience.",
                    Price = 2200,
                    Sqft = 5000,
                    Occupancy = 9,
                    ImageUrl = "/assets/luxury-villa-with-ocean-view.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Mediterranean Garden Villa",
                    Description = "Charming Mediterranean villa with lavender garden and stone pathway. Traditional elegance meets modern comfort.",
                    Price = 1200,
                    Sqft = 3500,
                    Occupancy = 6,
                    ImageUrl = "/assets/mediterranean-villa-with-lavender-garden-stone-pathway.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Cliffside Modern Villa",
                    Description = "Dramatic modern villa perched on a cliff. Architectural excellence with spectacular elevated views and contemporary design.",
                    Price = 1900,
                    Sqft = 4500,
                    Occupancy = 7,
                    ImageUrl = "/assets/modern-cliffside-villa.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Villa
                {
                    Name = "Architectural Dream Villa",
                    Description = "Luxurious villa showcasing modern architectural design. State-of-the-art construction with unparalleled attention to detail.",
                    Price = 2300,
                    Sqft = 5200,
                    Occupancy = 10,
                    ImageUrl = "/assets/view-luxurious-villa-with-modern-architectural-design.jpg",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            };

            await dbContext.Villas.AddRangeAsync(villas);
            await dbContext.SaveChangesAsync();
        }
    }
}