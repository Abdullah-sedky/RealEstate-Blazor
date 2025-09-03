using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CompoundRepository : ICompoundRepository
    {
        private readonly ApplicationDbContext _context;

        public CompoundRepository(ApplicationDbContext context)
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

        public async Task<Compound> CreateCompoundAsync(Compound compound)
        {
            _context.Compounds.Add(compound);
            await _context.SaveChangesAsync();
            return compound;
        }

        public async Task EditCompoundInfoAsync(int id, Compound compound)
        {
            var compToEdit = await _context.Compounds.FindAsync(id);
            if (compToEdit != null)
            {
                compToEdit.Name = compound.Name;
                compToEdit.Description = compound.Description;
                compToEdit.CityId = compound.CityId;
                await _context.SaveChangesAsync();
            }
        }

    }
}

