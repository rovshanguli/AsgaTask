using DomainLayer.Entities;
using ServiceLayer.DTOs.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDto registerDto);
        Task Update(AppUser appUser, UpdateUserDto updateuserDto);
        Task UpdatePassword(AppUser appUser, UpdatePasswordDto updatePasswordDto);
        Task<string> Login(LoginDto loginDto);
        Task ConfirmEmail(string userId, string token);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<List<UserDto>> GetAllUsers();
        Task ChangeRole(string Id);
        Task<IList<string>> GetUserRoles(string email);
    }
}
