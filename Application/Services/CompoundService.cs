using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RealEstateBlazor.Data;
namespace Application.Services
{
    public class CompoundService : ICompoundService
    {
        private readonly ApplicationDbContext _context;

        public CompoundService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Compound>> GetAllCompoundsAsync()
        {
            return await _context.Compounds.ToListAsync();
        }

        public async Task<Compound> GetCompoundByIdAsync(int id)
        {
            return await _context.Compounds.FindAsync(id);
        }

        public async Task RemoveCompoundById(int id)
        {
            var compToRemove = await _context.Compounds.FindAsync(id);
            if (compToRemove != null)
            {
                _context.Compounds.Remove(compToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditCompoundInfoAsync(int id, Compound compound)
        {
            var compToEdit = await _context.Compounds.FindAsync(id);
            if (compToEdit != null)
            {
                compToEdit.Properties = compound.Properties;
                compToEdit.City=compound.City;
                compToEdit.CityId = compound.CityId;
                compToEdit.Name=compound.Name;
                compToEdit.Description=compound.Description;
                await _context.SaveChangesAsync();
            }
        }


    }
}
