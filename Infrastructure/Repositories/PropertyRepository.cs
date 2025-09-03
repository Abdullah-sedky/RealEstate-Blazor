using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task RemovePropertyById(int id)
        {
            var propToRemove = await _context.Properties.FindAsync(id);
            if (propToRemove != null)
            {
                _context.Properties.Remove(propToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditPropertyInfoAsync(int id, Property property)
        {
            var propToEdit = await _context.Properties.FindAsync(id);
            if (propToEdit != null)
            {
                propToEdit.Furnished = property.Furnished;
                propToEdit.Name = property.Name;
                propToEdit.Description = property.Description;
                propToEdit.Price = property.Price;
                propToEdit.Status = property.Status;
                propToEdit.Bedrooms = property.Bedrooms;
                propToEdit.Bathrooms = property.Bathrooms;
                propToEdit.AreaSize = property.AreaSize;
                propToEdit.Compound = property.Compound;
                propToEdit.CompoundId = property.CompoundId;
                propToEdit.YearBuilt = property.YearBuilt;
                propToEdit.Photos = property.Photos;
                propToEdit.Location = property.Location;
                propToEdit.LocationId = property.LocationId;
                propToEdit.PropertyType = property.PropertyType;
                await _context.SaveChangesAsync();
            }

        }
    }
}
