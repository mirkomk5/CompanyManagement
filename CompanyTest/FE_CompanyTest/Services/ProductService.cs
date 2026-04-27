using BE_CompanyTest.Models;
using DTO_CompanyTest;
using FE_CompanyTest.Interfaces;
using FE_CompanyTest.Misc;
using System.Net.Http.Json;


namespace FE_CompanyTest.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(bool status, string message)> CreateProductAsync(DTO_Product product, string tokenId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Constants.API_BASEURL + Constants.API_CREATE_PRODUCT);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenId);
            request.Content = JsonContent.Create(product);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return (false, $"{response.StatusCode}");

            return (true, "Product created successfully");
        }

        public async Task<List<DTO_Product>> GetProductsAsync(string token, int pageNumber, int rowPerPage)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Constants.API_BASEURL + Constants.API_PRODUCTS_TABLE + $"{pageNumber}/{rowPerPage}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var results = await response.Content.ReadFromJsonAsync<List<DTO_Product>>();
            return results;
        }

        public async Task<DTO_Result<Product?>> UpdateProductAsync(DTO_Product product, string tokenId)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, Constants.API_BASEURL + Constants.API_UPDATE_PRODUCT);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenId);
            request.Content = JsonContent.Create(product);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                return new DTO_Result<Product?>(false, $"{response.StatusCode} {errorMessage}");
            }

            var result = await response.Content.ReadFromJsonAsync<DTO_Result<Product?>>();
            return result;
        }
    }
}
