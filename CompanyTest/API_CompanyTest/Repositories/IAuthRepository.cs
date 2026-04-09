using API_CompanyTest.Security;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Repositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(DTO_Credentials credentials);
    }

    public class AuthRepository(CompanyTestContext context) : IAuthRepository
    {
        public async Task<User> RegisterAsync(DTO_Credentials credentials)
        {
            User userProfile = new User
            {
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
            var savingProcess = await context.SaveChangesAsync();

            return userProfile;
        }
    }
}
