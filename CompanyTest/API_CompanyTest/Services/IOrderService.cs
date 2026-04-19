using API_CompanyTest.Repositories;
using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Services
{
    public interface IOrderService
    {
        Task<DTO_Result<Order>> CreateOrderAsync(DTO_Order order);
        Task<DTO_Result<Order>> DeleteOrderAsync(Guid id);
        Task<DTO_Result<Order>> UpdateOrderAsync(Guid id, DTO_Order order);
        Task<List<DTO_OrderTable>> GetOrdersAsync(int from, int resultsAmount);
    }

    public class OrderService(CompanyTestContext context, IMapper mapper, IOrdersRepository orderRepo) : IOrderService
    {
        public async Task<DTO_Result<Order>> CreateOrderAsync(DTO_Order order)
        {
            // validazione id utente
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == order.CustomerId);
            if(user is null)            
                return new DTO_Result<Order>(false, "User not found.");

            // validazione id prodotto
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == order.ProductId);
            if(product is null)            
                return new DTO_Result<Order>(false, "Product not found.");


            var mappedOrder = mapper.Map<Order>(order);
            var result = await orderRepo.CreateOrderAsync(mappedOrder);
            return result;
        }

        public async Task<DTO_Result<Order>> DeleteOrderAsync(Guid id)
        {
            if(id == Guid.Empty)
                return new DTO_Result<Order>(false, "Error: Invalid order ID");

            // validazione ordine
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return new DTO_Result<Order>(false, "Error: Order not found");

            var result = await orderRepo.DeleteOrderAsync(order);
            return result;
        }


        public async Task<DTO_Result<Order>> UpdateOrderAsync(Guid id, DTO_Order order_dto)
        {
            if(id == Guid.Empty)
                return new DTO_Result<Order>(false, "Error: Invalid order ID");

            var ord = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (ord == null)
                return new DTO_Result<Order>(false, "Error: Order not found");

            var result = await orderRepo.UpdateOrderAsync(id, order_dto);
            return result;
        }


        public async Task<List<DTO_OrderTable>> GetOrdersAsync(int from, int resultsAmount)
        {
            if (from < 0 || resultsAmount <= 0)
                return null;

            var result = await orderRepo.GetOrdersAsync(from, resultsAmount);
            return result;
        }

    }
}
