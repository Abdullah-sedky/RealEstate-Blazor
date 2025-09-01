using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Compound
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CompoundId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public List<Property> Properties { get; set; } = new List<Property>();

    }
}
