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
            return await _context.Properties
                .Include(p => p.Photos)
                .Include(p => p.Compound)
                    .ThenInclude(c => c.City)
                        .ThenInclude(city => city.Country)
                .Include(p => p.Location)
                    .ThenInclude(l => l.City)
                        .ThenInclude(city => city.Country)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.Photos)
                .Include(p => p.Compound)
                    .ThenInclude(c => c.City)
                        .ThenInclude(city => city.Country)
                .Include(p => p.Location)
                    .ThenInclude(l => l.City)
                        .ThenInclude(city => city.Country)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PropertyId == id);
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
            var propToEdit = await _context.Properties
                .Include(p => p.Location)
                .FirstOrDefaultAsync(p => p.PropertyId == id);
                
            if (propToEdit != null)
            {
                // Update basic property fields
                propToEdit.Furnished = property.Furnished;
                propToEdit.Name = property.Name;
                propToEdit.Description = property.Description;
                propToEdit.Price = property.Price;
                propToEdit.Status = property.Status;
                propToEdit.Bedrooms = property.Bedrooms;
                propToEdit.Bathrooms = property.Bathrooms;
                propToEdit.AreaSize = property.AreaSize;
                propToEdit.YearBuilt = property.YearBuilt;
                propToEdit.PropertyType = property.PropertyType;
                propToEdit.CompoundId = property.CompoundId;

                // Handle Location update
                if (property.Location != null)
                {
                    if (propToEdit.Location != null)
                    {
                        // Update existing location
                        propToEdit.Location.Address = property.Location.Address;
                        propToEdit.Location.PostalCode = property.Location.PostalCode;
                        propToEdit.Location.Latitude = property.Location.Latitude;
                        propToEdit.Location.Longitude = property.Location.Longitude;
                        propToEdit.Location.CityId = property.Location.CityId;
                    }
                    else if (property.Location.LocationId > 0)
                    {
                        // Link to existing location
                        propToEdit.LocationId = property.Location.LocationId;
                    }
                    else
                    {
                        // Create new location
                        var newLocation = new Location
                        {
                            Address = property.Location.Address,
                            PostalCode = property.Location.PostalCode,
                            Latitude = property.Location.Latitude,
                            Longitude = property.Location.Longitude,
                            CityId = property.Location.CityId
                        };
                        _context.Locations.Add(newLocation);
                        await _context.SaveChangesAsync(); // Save to get the LocationId
                        propToEdit.LocationId = newLocation.LocationId;
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
