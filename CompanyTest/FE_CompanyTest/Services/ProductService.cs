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
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7110/v1/";
        private readonly string _apiOrdersTable = "Products/get-all";

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<DTO_Product>> GetProductsAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + _apiOrdersTable);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var results = await response.Content.ReadFromJsonAsync<List<DTO_Product>>();
            return results;
        }
    }
}
