using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CompoundService : ICompoundService
    {
        private readonly ICompoundRepository _repository;

        public CompoundService(ICompoundRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Compound>> GetAllCompoundsAsync()
        {
            return await _repository.GetAllCompoundsAsync();
        }

        public async Task<Compound> GetCompoundByIdAsync(int id)
        {
            return await _repository.GetCompoundByIdAsync(id);
        }

        public async Task<Compound> CreateCompoundAsync(Compound compound)
        {
            return await _repository.CreateCompoundAsync(compound);
        }

        public async Task<Compound> UpdateCompoundAsync(int id, Compound compound)
        {
            await _repository.EditCompoundInfoAsync(id, compound);
            return await _repository.GetCompoundByIdAsync(id);
        }

        public async Task<bool> DeleteCompoundAsync(int id)
        {
            await _repository.RemoveCompoundById(id);
            return true;
        }
    }
}
