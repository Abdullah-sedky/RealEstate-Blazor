using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using Application.Mappers;
using Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        
        public PropertyService(IPropertyRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<PropertyListDTO>> GetCustomerPropertyList()
        {
            var properties = await _repository.GetAllPropertiesAsync();
            return PropertyMapper.ToPropertyListDTOs(properties);
        }

        public async Task<List<Property>> GetAllProperties()
        {
            var properties = await _repository.GetAllPropertiesAsync();
            return properties;
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _repository.GetPropertyByIdAsync(id);
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            return await _repository.CreatePropertyAsync(property);
        }

        public async Task<Property> UpdatePropertyAsync(int id, Property property)
        {
            await _repository.EditPropertyInfoAsync(id, property);
            return await _repository.GetPropertyByIdAsync(id);
        }

        public async Task<bool> DeletePropertyAsync(int id)
        {
            await _repository.RemovePropertyById(id);
            return true;
        }
    }
}
