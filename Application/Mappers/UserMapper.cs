using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Mappers
{
    public static class UserMapper
    {
        public static async Task<UserListDTO> ToUserListDTO(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            var roles = ( await userManager.GetRolesAsync(user)).ToList();
            return new UserListDTO
            {
                Id = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                AccessFailedCount = user.AccessFailedCount,
                PropertiesCount=user.Properties.Count,
                Roles = roles

            };
        }

        public static async Task<List<UserListDTO>> ToUserListDTOs(List<ApplicationUser> users, UserManager<ApplicationUser> userManager)
        {
            var tasks = users.Select(user => ToUserListDTO(user, userManager));
            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        public static ApplicationUser ToApplicationUser(CreateUserDTO dto)
        {
            return new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                EmailConfirmed = dto.EmailConfirmed,
                PhoneNumberConfirmed = dto.PhoneNumberConfirmed
            };
        }
    }
}
