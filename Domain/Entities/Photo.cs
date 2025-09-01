using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Caption { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = null!;
        public bool IsPrim { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; } = new Property();

    }
}
