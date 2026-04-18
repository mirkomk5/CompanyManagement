using API_CompanyTest.Repositories;
using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Services
{
    public interface IAuthenticationService
    {
        Task<DTO_AuthResponse> RegisterAsync(DTO_RegisterRequest credentials);
        Task<DTO_AuthResponse> LoginAsync(DTO_AuthRequest credentials);
    }

    public class AuthenticationService(CompanyTestContext context, IAuthRepository authRepo, ITokenService tokenService) : IAuthenticationService
    {

        public async Task<DTO_AuthResponse> RegisterAsync(DTO_RegisterRequest credentials)
        {
            // Controllo esistenza profilo con stessa email
            var isProfileExisting = await context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email);
            if (isProfileExisting != null)
            {
                return new DTO_AuthResponse
                {
                    UserId = Guid.Empty,
                    TokenId = string.Empty,
                    Message = "There is already profile registered with this email",
                    Success = false
                };
            }

            var result = await authRepo.RegisterAsync(credentials);
            if (result == null)
            {
                return new DTO_AuthResponse
                {
                    UserId = Guid.Empty,
                    TokenId = string.Empty,
                    Message = "Registration failed. Check the data you entered.",
                    Success = false
                };
            }

            

            var tokenId = tokenService.CreateToken(result.Id, result.AdminLevel.ToString());

            DTO_AuthResponse response = new DTO_AuthResponse
            {
                UserId = result.Id,
                TokenId = tokenId,
                Message = "Registered successfully",
                Success = true,
            };

            return response;
        }


        public async Task<DTO_AuthResponse> LoginAsync(DTO_AuthRequest credentials)
        {
            var result = await authRepo.LoginAsync(credentials);
            if(result == null) return new DTO_AuthResponse
            {
                UserId = Guid.Empty,
                TokenId = string.Empty,
                Message = "Invalid email or password",
                Success = false
            };

            var tokenId = tokenService.CreateToken(result.Id, result.AdminLevel.ToString());
            DTO_AuthResponse response = new DTO_AuthResponse
            {
                UserId = result.Id,
                TokenId = tokenId,
                Message = "Logged in successfully",
                Success = true,
            };
            return response;
        }
    }
}
