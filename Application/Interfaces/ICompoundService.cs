using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICompoundService
    {
        Task<List<Compound>> GetAllCompoundsAsync();
        Task<Compound> GetCompoundByIdAsync(int id);
        Task<Compound> CreateCompoundAsync(Compound compound);
        Task<Compound> UpdateCompoundAsync(int id, Compound compound);
        Task<bool> DeleteCompoundAsync(int id);
    }
}
