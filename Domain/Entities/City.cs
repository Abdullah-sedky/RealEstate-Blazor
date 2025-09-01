using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Compound> Compounds { get; set; } = new List<Compound>();
        public int CountryId { get; set; }  //foreign key: every city/cities belong to a country
        public Country Country { get; set; } = null!;
    }
}
