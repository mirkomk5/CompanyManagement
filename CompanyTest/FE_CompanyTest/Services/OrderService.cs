using DTO_CompanyTest;
using FE_CompanyTest.Interfaces;
using FE_CompanyTest.Misc;
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

        public OrderService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<DTO_OrderTable>> GetOrdersAsync(string tokenId, int from, int amount)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Constants.API_BASEURL + Constants.API_ORDERS_TABLE + $"{from}/{amount}");
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
