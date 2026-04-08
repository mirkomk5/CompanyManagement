using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
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
    }
}
