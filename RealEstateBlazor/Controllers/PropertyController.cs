using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;
using Domain.Entities;

namespace RealEstateBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyListDTO>>> GetAllProperties()
        {
            try
            {
                var properties = await _propertyService.GetCustomerPropertyList();
                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            try
            {
                var property = await _propertyService.GetPropertyByIdAsync(id);
                if (property == null)
                {
                    return NotFound($"Property with ID {id} not found.");
                }
                return Ok(property);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Property>> CreateProperty([FromBody] Property property)
        {
            try
            {
                if (property == null)
                {
                    return BadRequest("Property data is required.");
                }

                var createdProperty = await _propertyService.CreatePropertyAsync(property);
                return CreatedAtAction(nameof(GetProperty), new { id = createdProperty.PropertyId }, createdProperty);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Property>> UpdateProperty(int id, [FromBody] Property property)
        {
            try
            {
                if (property == null)
                {
                    return BadRequest("Property data is required.");
                }

                if (id != property.PropertyId)
                {
                    return BadRequest("Property ID mismatch.");
                }

                var updatedProperty = await _propertyService.UpdatePropertyAsync(id, property);
                if (updatedProperty == null)
                {
                    return NotFound($"Property with ID {id} not found.");
                }

                return Ok(updatedProperty);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            try
            {
                var result = await _propertyService.DeletePropertyAsync(id);
                if (!result)
                {
                    return NotFound($"Property with ID {id} not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
