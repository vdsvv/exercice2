using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User userToUpdate);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<User> GetUserByIdAsync(Guid userId);
        Task<List<User>> GetUsersAsync();
    }
}