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
    public class OrderService : IOrdersService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7110/v1/";
        private readonly string _apiOrdersTable = "Orders/ordersTable/"; 

        public OrderService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<DTO_OrderTable>> GetOrdersAsync(string tokenId, int from, int amount)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + _apiOrdersTable + $"{from}/{amount}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenId);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string rawJson = await response.Content.ReadAsStringAsync();
            Console.WriteLine(rawJson); 

            var result = await response.Content.ReadFromJsonAsync<List<DTO_OrderTable>>();
            return result;
        }
    }
}
