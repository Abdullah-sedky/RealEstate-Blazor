using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;

namespace RealEstateBlazor.Controllers
{
    [ApiController]
    [Route("api/Compounds")]
    public class CompoundController : ControllerBase
    {
        private readonly ICompoundService _compoundService;

        public CompoundController(ICompoundService compoundService)
        {
            _compoundService = compoundService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compound>>> GetAllCompounds()
        {
            try
            {
                var compounds = await _compoundService.GetAllCompoundsAsync();
                return Ok(compounds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compound>> GetCompound(int id)
        {
            try
            {
                var compound = await _compoundService.GetCompoundByIdAsync(id);
                if (compound == null)
                {
                    return NotFound($"Compound with ID {id} not found.");
                }
                return Ok(compound);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Compound>> CreateCompound([FromBody] Compound compound)
        {
            try
            {
                if (compound == null)
                {
                    return BadRequest("Compound data is required.");
                }

                var createdCompound = await _compoundService.CreateCompoundAsync(compound);
                return CreatedAtAction(nameof(GetCompound), new { id = createdCompound.CompoundId }, createdCompound);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Compound>> UpdateCompound(int id, [FromBody] Compound compound)
        {
            try
            {
                if (compound == null)
                {
                    return BadRequest("Compound data is required.");
                }

                if (id != compound.CompoundId)
                {
                    return BadRequest("Compound ID mismatch.");
                }

                var updatedCompound = await _compoundService.UpdateCompoundAsync(id, compound);
                if (updatedCompound == null)
                {
                    return NotFound($"Compound with ID {id} not found.");
                }

                return Ok(updatedCompound);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompound(int id)
        {
            try
            {
                var result = await _compoundService.DeleteCompoundAsync(id);
                if (!result)
                {
                    return NotFound($"Compound with ID {id} not found.");
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
