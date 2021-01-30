using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly EducationContext _educationContext;

        public UserService(EducationContext dataContext)
        {
            _educationContext = dataContext;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            await _educationContext.Users.AddAsync(user);
            int createdCount = await _educationContext.SaveChangesAsync();
            return createdCount > 0;
        }

        public async Task<bool> UpdateUserAsync(User userToUpdate)
        {
            _educationContext.Users.Update(userToUpdate);
            var updatedCount = await _educationContext.SaveChangesAsync();
            return updatedCount > 0;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null)
            {
                return false;
            }
            _educationContext.Users.Remove(user);
            int deletedCount = await _educationContext.SaveChangesAsync();
            return deletedCount > 0;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _educationContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _educationContext.Users.ToListAsync();
        }
    }
}