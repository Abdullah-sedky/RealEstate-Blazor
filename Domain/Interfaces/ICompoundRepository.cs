using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Domain.Interfaces
{
    public interface ICompoundRepository
    {
        Task<List<Compound>> GetAllCompoundsAsync();
        Task<Compound> GetCompoundByIdAsync(int id);
        Task<Compound> CreateCompoundAsync(Compound compound);
        System.Threading.Tasks.Task EditCompoundInfoAsync(int id, Compound compound);
        System.Threading.Tasks.Task RemoveCompoundById(int id);
    }
}
