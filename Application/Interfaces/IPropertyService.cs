using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyListDTO>> GetCustomerPropertyList();
        Task<List<Property>> GetAllProperties();
        Task<Property> GetPropertyByIdAsync(int id);
        Task<Property> CreatePropertyAsync(Property property);
        Task<Property> UpdatePropertyAsync(int id, Property property);
        Task<bool> DeletePropertyAsync(int id);
    }
}
