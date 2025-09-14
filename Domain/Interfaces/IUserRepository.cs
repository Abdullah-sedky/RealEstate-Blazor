using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<List<ApplicationUser>> GetUsersByRoleAsync(string role);
        Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> UserExistsAsync(string id);
        Task<List<string>> GetUserRolesAsync(ApplicationUser user);
        Task<bool> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<bool> RemoveUserFromRoleAsync(ApplicationUser user, string role);
    }
}
