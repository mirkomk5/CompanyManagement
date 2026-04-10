using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(string userId);
    }

    public class UserRepository(CompanyTestContext context) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            context.Users.Add(user);
            var result = await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            if (!Guid.TryParse(userId, out var parsedGuid)) return false;

            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == parsedGuid);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
