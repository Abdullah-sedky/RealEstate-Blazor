using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.DTOs
{
    public class PropertyListDTO
    {
        public int PropertyId {  get; set; }
        public string Name { get; set; } = null!; 
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PropertyType PropertyType { get; set; }
        public PropertyStatus Status { get; set; }
        public string? PrimaryPhotoUrl { get; set; }


    }
}
