using System.Reflection.Metadata;
using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task EditPropertyInfoAsync(int id, Property property);
        Task RemovePropertyById(int id);

    }
}
