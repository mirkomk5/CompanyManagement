using BE_CompanyTest.Models;
using Dapper;
using DTO_CompanyTest;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(Product product);
        Task<bool> SP_CreateProductAsync(Product product);
        Task<DTO_ResponseMessage> UpdateProductAsync(Guid id, DTO_Product product);
        Task<DTO_ResponseMessage> DeleteProductAsync(Guid id);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>?> GetAllProductsAsync();
    }

    public class ProductRepository(CompanyTestContext context) : IProductRepository
    {
        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SP_CreateProductAsync(Product product)
        {
            string connectionString = context.Database.GetConnectionString();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        ProductName = product.ProductName,
                        Description = product.Description,
                        Price = product.Price,
                        Discount = product.Discount
                    };

                    var newId = await connection.QuerySingleAsync<Guid>(
                        "sp_InsertProduct",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure
                    );
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product via stored procedure: {ex.Message}");
                return false;
            }
        }

        public async Task<DTO_ResponseMessage> DeleteProductAsync(Guid id)
        {
            // Per una questione di legame di product con order, mi assicuro di eliminare prima il prodotto dagli ordini
            var orders = context.Orders.Where(o => o.ProductId == id);
            if(orders != null)
                context.Orders.RemoveRange(orders);

            // .. proseguo poi con l'eliminazione del prodotto
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return new DTO_ResponseMessage(false, "Error: No product id found");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return new DTO_ResponseMessage(true, "Product removed succesfully");
        }

        public async Task<IEnumerable<Product>?> GetAllProductsAsync()
        {
            try
            {
                var allProducts = await context.Products.ToListAsync();
                return allProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving products: {ex.Message}");
                return null;
            }
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<DTO_ResponseMessage> UpdateProductAsync(Guid guid, DTO_Product dtoProduct)
        {
            var target = await context.Products.FirstOrDefaultAsync(p => p.Id == guid);

            if (target == null)            
                return new DTO_ResponseMessage(false, "Product not found");
            

            try
            {
                target.ProductName = dtoProduct.ProductName;
                target.Description = dtoProduct.Description;
                target.Price = dtoProduct.Price;
                target.Discount = dtoProduct.Discount;

                //context.Entry(target).CurrentValues.SetValues(product);

                await context.SaveChangesAsync();
                return new DTO_ResponseMessage(true, "Product update succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return new DTO_ResponseMessage(false, $"Error during update: {ex.Message}");
            }
        }
    }
}
