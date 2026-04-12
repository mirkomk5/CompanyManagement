using API_CompanyTest.Repositories;
using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Services
{
    public interface IOrderService
    {
        Task<DTO_ResponseMessage> CreateOrderAsync(DTO_Order order);
        Task<DTO_ResponseMessage> DeleteOrderAsync(Guid id);
        Task<DTO_ResponseMessage> UpdateOrderAsync(Guid id, DTO_Order order);
    }

    public class OrderService(CompanyTestContext context, IMapper mapper, IOrdersRepository orderRepo) : IOrderService
    {
        public async Task<DTO_ResponseMessage> CreateOrderAsync(DTO_Order order)
        {
            // validazione id utente
            var user = await context.Users.FirstAsync(x => x.Id == order.CustomerId);
            if(user == null)            
                return new DTO_ResponseMessage(false, "User not found.");

            // validazione id prodotto
            var product = await context.Products.FirstAsync(x => x.Id == order.ProductId);
            if(product == null)            
                return new DTO_ResponseMessage(false, "Product not found.");


            var mappedOrder = mapper.Map<Order>(order);
            var result = await orderRepo.CreateOrderAsync(mappedOrder);
            return result;
        }

        public async Task<DTO_ResponseMessage> DeleteOrderAsync(Guid id)
        {
            if(id == Guid.Empty)
                return new DTO_ResponseMessage(false, "Error: Invalid order ID");

            // validazione ordine
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return new DTO_ResponseMessage(false, "Error: Order not found");

            var result = await orderRepo.DeleteOrderAsync(order);
            return result;
        }

        public async Task<DTO_ResponseMessage> UpdateOrderAsync(Guid id, DTO_Order order_dto)
        {
            if(id == Guid.Empty)
                return new DTO_ResponseMessage(false, "Error: Invalid order ID");

            var ord = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (ord == null)
                return new DTO_ResponseMessage(false, "Error: Order not found");

            var result = await orderRepo.UpdateOrderAsync(id, order_dto);
            return result;
        }
    }
}
