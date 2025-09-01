using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Interfaces
{
    public interface ICompoundService
    {
        Task<List<Compound>> GetAllCompoundsAsync();
        Task<Compound> GetCompoundByIdAsync(int id);
        Task EditCompoundInfoAsync(int id, Compound compound);
        Task RemoveCompoundById(int id);
    }
}
