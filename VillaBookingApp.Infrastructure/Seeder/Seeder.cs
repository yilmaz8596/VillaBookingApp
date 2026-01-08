using Microsoft.EntityFrameworkCore;
using VillaBookingApp.Infrastructure.Data;
using VillaBookingApp.Domain.Entities;
using System.Linq;

namespace VillaBookingApp.Infrastructure.Seeder
{
    public class Seeder
    {
        private readonly AppDbContext _dbContext;

        public Seeder(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            // Seed amenities if none exist
            if (!await _dbContext.Amenities.AnyAsync())
            {
                var amenities = new List<Amenity>
                {
                    new Amenity { Name = "Private Swimming Pool", Description = "Private pool for guests.", IconUrl = "/icons/pool.svg" },
                    new Amenity { Name = "High-Speed WiFi", Description = "Reliable high-speed internet.", IconUrl = "/icons/wifi.svg" },
                    new Amenity { Name = "Fully Equipped Kitchen", Description = "Modern appliances and utensils.", IconUrl = "/icons/kitchen.svg" },
                    new Amenity { Name = "Air Conditioning", Description = "Climate control throughout the property.", IconUrl = "/icons/ac.svg" },
                    new Amenity { Name = "Free Parking", Description = "On-site parking available.", IconUrl = "/icons/parking.svg" },
                    new Amenity { Name = "24/7 Security", Description = "Security services are available around the clock.", IconUrl = "/icons/security.svg" },
                    new Amenity { Name = "Smart TV", Description = "Smart television with streaming apps.", IconUrl = "/icons/tv.svg" },
                    new Amenity { Name = "Garden & Terrace", Description = "Outdoor space with terrace and garden.", IconUrl = "/icons/garden.svg" },

                    // Additional amenities
                    new Amenity { Name = "Hot Tub", Description = "Relaxing hot tub/spa area.", IconUrl = "/icons/hottub.svg" },
                    new Amenity { Name = "Gym", Description = "Private fitness/gym equipment.", IconUrl = "/icons/gym.svg" },
                    new Amenity { Name = "BBQ Grill", Description = "Outdoor BBQ and grilling area.", IconUrl = "/icons/bbq.svg" },
                    new Amenity { Name = "Washer & Dryer", Description = "In-unit washer and dryer.", IconUrl = "/icons/laundry.svg" },
                    new Amenity { Name = "Fireplace", Description = "Indoor fireplace for cozy evenings.", IconUrl = "/icons/fireplace.svg" },
                    new Amenity { Name = "Ocean View", Description = "Unobstructed ocean view.", IconUrl = "/icons/ocean.svg" },
                    new Amenity { Name = "Pet Friendly", Description = "Pets are allowed.", IconUrl = "/icons/pet.svg" },
                    new Amenity { Name = "Breakfast Included", Description = "Daily breakfast included.", IconUrl = "/icons/breakfast.svg" },
                    new Amenity { Name = "Airport Shuttle", Description = "Airport pickup/drop-off service.", IconUrl = "/icons/shuttle.svg" },
                    new Amenity { Name = "Beach Access", Description = "Direct access to the beach.", IconUrl = "/icons/beach.svg" }
                };

                await _dbContext.Amenities.AddRangeAsync(amenities);
                await _dbContext.SaveChangesAsync();
            }

            // Seed villas only if none exist
            if (await _dbContext.Villas.AnyAsync())
            {
                return; // Data already seeded
            }

            var allAmenities = await _dbContext.Amenities.ToListAsync();

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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "High-Speed WiFi","Smart TV","Air Conditioning","24/7 Security","Gym","Washer & Dryer",
                        "Free Parking","Fully Equipped Kitchen","Breakfast Included","Airport Shuttle"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "Private Swimming Pool","Fully Equipped Kitchen","Free Parking","Smart TV","BBQ Grill",
                        "Washer & Dryer","Air Conditioning","High-Speed WiFi","Hot Tub","24/7 Security"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "Garden & Terrace","High-Speed WiFi","Air Conditioning","Ocean View","BBQ Grill",
                        "Smart TV","Free Parking","Beach Access","Breakfast Included","Airport Shuttle"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "Garden & Terrace","Free Parking","24/7 Security","Fireplace","Washer & Dryer",
                        "Fully Equipped Kitchen","High-Speed WiFi","Smart TV","Pet Friendly","Air Conditioning"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "Private Swimming Pool","Garden & Terrace","Smart TV","Hot Tub","BBQ Grill",
                        "High-Speed WiFi","Air Conditioning","Free Parking","Washer & Dryer","24/7 Security"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "Free Parking","High-Speed WiFi","Smart TV","Ocean View","Private Swimming Pool",
                        "Hot Tub","Beach Access","Airport Shuttle","Breakfast Included","24/7 Security"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "Garden & Terrace","Fully Equipped Kitchen","Air Conditioning","BBQ Grill","Washer & Dryer",
                        "High-Speed WiFi","Free Parking","Smart TV","Pet Friendly","Fireplace"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "High-Speed WiFi","Smart TV","24/7 Security","Ocean View","Gym",
                        "Air Conditioning","Free Parking","Washer & Dryer","Breakfast Included","Airport Shuttle"
                    }.Contains(a.Name)).ToList()
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
                    UpdatedDate = DateTime.Now,
                    Amenities = allAmenities.Where(a => new[]
                    {
                        "High-Speed WiFi","Smart TV","Air Conditioning","Free Parking","Gym","Fireplace",
                        "Washer & Dryer","Fully Equipped Kitchen","24/7 Security","BBQ Grill"
                    }.Contains(a.Name)).ToList()
                }
            };

            await _dbContext.Villas.AddRangeAsync(villas);
            await _dbContext.SaveChangesAsync();
        }
    }
}
