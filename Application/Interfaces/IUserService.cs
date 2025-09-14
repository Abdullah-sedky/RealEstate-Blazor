using Domain.Entities;
using Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<List<UserListDTO>> GetAllUsersDTOAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<List<ApplicationUser>> GetUsersByRoleAsync(string role);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<List<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string role);
        Task<bool> UserExistsAsync(string id);
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
    }
}
