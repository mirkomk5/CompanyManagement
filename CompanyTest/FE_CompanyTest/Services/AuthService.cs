using DTO_CompanyTest;
using FE_CompanyTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FE_CompanyTest.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _baseUrl = "https://localhost:7110/v1/";
        private readonly string _apiLogin = "Auth/login";
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<DTO_AuthResponse> LoginAsync(DTO_AuthRequest dto_auth)
        {
            var result = await _httpClient.PostAsJsonAsync(_baseUrl + _apiLogin, dto_auth);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<DTO_AuthResponse>();
                return response;
            }
            else
            {
                return null;
            }
            
        }
    }
}
