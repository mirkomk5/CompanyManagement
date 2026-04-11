using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IOrdersRepository
    {
        Task<DTO_ResponseMessage> CreateOrderAsync(Order order);
        Task<DTO_ResponseMessage> DeleteOrderAsync(Order order);
        Task<DTO_ResponseMessage> UpdateOrderAsync(Guid id, DTO_Order order);
    }

    public class OrdersRepository(CompanyTestContext context) : IOrdersRepository
    {
        public async Task<DTO_ResponseMessage> CreateOrderAsync(Order order)
        {
            try
            {
                context.Orders.Add(order);
                var result = await context.SaveChangesAsync();
                return new DTO_ResponseMessage(result > 0, result > 0 ? "Order created successfully." : "Failed to create order.");
            }
            catch (Exception ex)
            {
                return new DTO_ResponseMessage(false, $"Error creating order: {ex.Message}");
            }
        }
        public async Task<DTO_ResponseMessage> DeleteOrderAsync(Order order)
        {
            context.Remove(order);
            var result = await context.SaveChangesAsync();
            return new DTO_ResponseMessage(result > 0, result > 0 ? "Order deleted successfully." : "Failed to delete order.");

        }

        public async Task<DTO_ResponseMessage> UpdateOrderAsync(Guid id, DTO_Order order_dto)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if(order_dto.CustomerId.HasValue)
                order.CustomerId = order_dto.CustomerId.Value;

            if(order_dto.ProductId.HasValue)
                order.ProductId = order_dto.ProductId.Value;

            if(!string.IsNullOrEmpty(order_dto.Notes))
                order.Notes = order_dto.Notes;

            var result = await context.SaveChangesAsync();
            return new DTO_ResponseMessage(result > 0, result > 0 ? "Order updated successfully." : "Failed to update order.");
        }
    }   
}
