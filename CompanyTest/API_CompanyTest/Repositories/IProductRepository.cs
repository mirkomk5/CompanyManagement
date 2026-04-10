using BE_CompanyTest.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(Product product);
        Task<bool> SP_CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid id);
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

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return false;

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
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

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var target = await context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            
            if(target == null)
                return false;

            try
            {
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }
    }
}
