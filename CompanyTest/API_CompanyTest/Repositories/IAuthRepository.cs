using API_CompanyTest.Security;
using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(DTO_RegisterRequest credentials);
        Task<User> LoginAsync(DTO_AuthRequest credentials);
    }

    public class AuthRepository(CompanyTestContext context) : IAuthRepository
    {
        public async Task<User> RegisterAsync(DTO_RegisterRequest credentials)
        {
            User userProfile = new User
            {
                Email = credentials.Email,
                Name = credentials.Name,
                Surname = credentials.Surname,
                Address = credentials.Address,
                AdminLevel = 0,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
            };

            // Hash password before saving it
            string hashedPass = PasswordHasher.HashPassword(credentials.Password);

            Credential newCredential = new Credential
            {
                UserId = userProfile.Id,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                Value = hashedPass
            };
            userProfile.Credentials.Add(newCredential);
            context.Users.Add(userProfile);

            await context.SaveChangesAsync();

            return userProfile;
        }

        public async Task<User> LoginAsync(DTO_AuthRequest credentials)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email);
            if (user == null) return null;

            var userCred = await context.Credentials.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (userCred == null) return null;

            bool isPasswordValid = PasswordHasher.VerifyPassword(credentials.Password, userCred.Value);
            if (!isPasswordValid) return null;
            return user;
        }
    }
}
