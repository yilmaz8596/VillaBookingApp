namespace VillaBookingApp.Web.ViewModels
{
    public class VillaVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Display-only projection (do not expose EF entities in a VM)
        public IReadOnlyList<AmenityItemVM> Amenities { get; init; } = Array.Empty<AmenityItemVM>();
    }

    public class AmenityItemVM
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public string? IconUrl { get; init; }
    }
}
