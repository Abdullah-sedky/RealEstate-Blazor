using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Property
    {
        public string Name { get; set; } = null!; // means value is initially empty, not null
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int PropertyId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public double AreaSize { get; set; }
        public PropertyStatus Status { get; set; }
        public int YearBuilt { get; set; }
        public bool Furnished { get; set; }

        public List<Photo> Photos { get; set; } = null!;

        public string UserId { get; set; } = null!; // Changed to string for Identity
        public ApplicationUser User { get; set; } = null!;

        public int CompoundId { get; set; }
        public Compound Compound { get; set; } = null!;

        public int LocationId { get; set; }
        public Location Location { get; set; } = null!; // not nullable, but will be filled later
    }
}
