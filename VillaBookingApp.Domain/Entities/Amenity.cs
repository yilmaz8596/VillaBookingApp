using System.Collections.Generic;

namespace VillaBookingApp.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }

        // Navigation for many-to-many with Villa
        public ICollection<Villa> Villas { get; set; } = new List<Villa>();
    }
}
