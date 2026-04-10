using API_CompanyTest.Repositories;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Services
{
    public interface IAuthenticationService
    {
        Task<DTO_AuthResponse> RegisterAsync(DTO_RegisterRequest credentials);
        Task<DTO_AuthResponse> LoginAsync(DTO_AuthRequest credentials);
    }

    public class AuthenticationService(IAuthRepository authRepo, ITokenService tokenService) : IAuthenticationService
    {

        public async Task<DTO_AuthResponse> RegisterAsync(DTO_RegisterRequest credentials)
        {
            var result = await authRepo.RegisterAsync(credentials);
            var tokenId = tokenService.CreateToken(result.Id, "0");

            if (result == null) return null;

            DTO_AuthResponse response = new DTO_AuthResponse
            {
                UserId = result.Id,
                TokenId = tokenId
            };

            return response;
        }


        public async Task<DTO_AuthResponse> LoginAsync(DTO_AuthRequest credentials)
        {
            var task = await authRepo.LoginAsync(credentials);
            if(task == null) return null;

            var tokenId = tokenService.CreateToken(task.Id, "0");
            DTO_AuthResponse response = new DTO_AuthResponse
            {
                UserId = task.Id,
                TokenId = tokenId
            };
            return response;
        }
    }
}
