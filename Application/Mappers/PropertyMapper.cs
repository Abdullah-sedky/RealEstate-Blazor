using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.DTOs;
namespace Application.Mappers
{
    public class PropertyMapper
    {
        public static PropertyListDTO ToListDTO(Property property)
        {
            return new PropertyListDTO
            {
                
                PropertyId = property.PropertyId,
                Name = property.Name,
                Status = property.Status,
                Price = property.Price,
                PropertyType = property.PropertyType,
                Description = property.Description,
                PrimaryPhotoUrl = property.Photos?.FirstOrDefault(p => p.IsPrim)?.ImageUrl
            };
        }
        public static List<PropertyListDTO> ToListDTOs(List<Property> properties)
        {
            return properties.Select(ToListDTO).ToList();
        }
    }
}
