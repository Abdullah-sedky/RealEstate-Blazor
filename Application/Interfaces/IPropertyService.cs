using System.Reflection.Metadata;
using Domain.Entities;
namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task EditPropertyInfoAsync(int id, Property property);
        Task RemovePropertyById(int id);

    }
}
