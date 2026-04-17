using DTO_CompanyTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FE_CompanyTest.Services
{
    public interface IClaimsService
    {
        Task<List<DTO_ClaimsTable>> GetClaimsTable(string tokenId);
    }

    public class ClaimsService : IClaimsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7110/v1/";
        private readonly string _apiOrdersTable = "Claims/claims-table/";


        public ClaimsService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<DTO_ClaimsTable>> GetClaimsTable(string tokenId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + _apiOrdersTable);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenId);

            var response = _httpClient.SendAsync(request).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch claims: {response.ReasonPhrase}");
            }

            var result = await response.Content.ReadFromJsonAsync<List<DTO_ClaimsTable>>();
            return result;
        }
    }
}
