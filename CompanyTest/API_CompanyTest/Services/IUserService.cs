using API_CompanyTest.Repositories;
using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Services
{
    public interface IUserService
    {
        Task<IEnumerable<DTO_User>> GetAllUsersAsync();
        Task<bool> CreateUserAsync(DTO_User user);
        Task<bool> DeleteUserAsync(string userId);
    }

    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {

        public async Task<IEnumerable<DTO_User>> GetAllUsersAsync()
        {
            var result = await userRepository.GetAllUsersAsync();
            var userList = mapper.Map<IEnumerable<DTO_User>>(result);
            return userList.ToList();
        }
        public async Task<bool> CreateUserAsync(DTO_User userDto)
        {
            var mapUser = mapper.Map<User>(userDto);

            try
            {
                await userRepository.CreateUserAsync(mapUser);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            try
            {
                var result = await userRepository.DeleteUserAsync(userId);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user: {ex.Message}");
            }
            return false;
        }
    }
}
