using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IOrdersRepository
    {
        Task<DTO_Result<Order>> CreateOrderAsync(Order order);
        Task<DTO_Result<Order>> DeleteOrderAsync(Order order);
        Task<DTO_Result<Order>> UpdateOrderAsync(Guid id, DTO_Order order);
        Task<List<DTO_OrderTable>> GetOrdersAsync(int from, int amount);
    }

    public class OrdersRepository(CompanyTestContext context) : IOrdersRepository
    {
        public async Task<DTO_Result<Order>> CreateOrderAsync(Order order)
        {
            try
            {
                context.Orders.Add(order);
                var result = await context.SaveChangesAsync();
                return new DTO_Result<Order>(result > 0, result > 0 ? "Order created successfully." : "Failed to create order.");
            }
            catch (Exception ex)
            {
                return new DTO_Result<Order>(false, $"Error creating order: {ex.Message}");
            }
        }
        public async Task<DTO_Result<Order>> DeleteOrderAsync(Order order)
        {
            context.Remove(order);
            var result = await context.SaveChangesAsync();
            return new DTO_Result<Order>(result > 0, result > 0 ? "Order deleted successfully." : "Failed to delete order.");

        }

        public async Task<DTO_Result<Order>> UpdateOrderAsync(Guid id, DTO_Order order_dto)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if(order is null)
                return new DTO_Result<Order>(false, "Order not found.");

            if (order_dto.CustomerId.HasValue)
                order.CustomerId = order_dto.CustomerId.Value;

            if (order_dto.ProductId.HasValue)
                order.ProductId = order_dto.ProductId.Value;

            if (!string.IsNullOrEmpty(order_dto.Notes))
                order.Notes = order_dto.Notes;

            var result = await context.SaveChangesAsync();
            return new DTO_Result<Order>(result > 0, result > 0 ? "Order updated successfully." : "Failed to update order.");
        }

        /// <summary>
        /// Restituisce lista di ordini concatenata con dati prodotto e cliente con paginazione
        /// </summary>
        /// <param name="from">Da n. record</param>
        /// <param name="resultsAmount">Quantità di risultati da prendere a partire dal record scelto</param>
        /// <returns></returns>
        public async Task<List<DTO_OrderTable>> GetOrdersAsync(int from, int resultsAmount)
        {
            List<DTO_OrderTable> orders = new List<DTO_OrderTable>();
            string connectionString = context.Database.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetOrdersPaged", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PageNumber", from);
                cmd.Parameters.AddWithValue("@PageSize", resultsAmount);

                await conn.OpenAsync();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new DTO_OrderTable
                        {
                            OrderId = reader["OrderId"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]) as DateTime?,
                            CustomerFullname = reader["CustomerFullname"].ToString(),
                            Address = reader["Address"].ToString(),
                            ProductName = reader["ProductName"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Notes = reader["Notes"].ToString()
                        });
                    }
                }
            }
            return orders;
        }

    }
}
