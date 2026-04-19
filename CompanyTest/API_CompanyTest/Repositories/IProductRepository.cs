using BE_CompanyTest.Models;
using Dapper;
using DTO_CompanyTest;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_CompanyTest.Repositories
{
    public interface IProductRepository
    {
        Task<DTO_Result<Product>> CreateProductAsync(Product product);
        Task<DTO_Result<Product>> SP_CreateProductAsync(Product product);
        Task<DTO_Result<Product>> UpdateProductAsync(Guid id, DTO_Product product);
        Task<DTO_Result<Product>> DeleteProductAsync(Guid id);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>?> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetAllProductsBySPAsync(int pageNumber, int rowPerPage);
    }

    public class ProductRepository(CompanyTestContext context) : IProductRepository
    {
        public async Task<DTO_Result<Product>> CreateProductAsync(Product product)
        {
            try
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return new DTO_Result<Product>(true, "Product created succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product: {ex.Message}");
                return new DTO_Result<Product>(false, $"Error during creation: {ex.Message}");
            }
        }

        public async Task<DTO_Result<Product>> SP_CreateProductAsync(Product product)
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
                return new DTO_Result<Product>(true, "Product created succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product via stored procedure: {ex.Message}");
                return new DTO_Result<Product>(false, $"Error during creation: {ex.Message}");
            }
        }

        public async Task<DTO_Result<Product>> DeleteProductAsync(Guid id)
        {
            // Per una questione di legame di product con order, mi assicuro di eliminare prima il prodotto dagli ordini
            var orders = context.Orders.Where(o => o.ProductId == id);
            if(orders != null)
                context.Orders.RemoveRange(orders);

            // .. proseguo poi con l'eliminazione del prodotto
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return new DTO_Result<Product>(false, "Error: No product id found");

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return new DTO_Result<Product>(true, "Product removed succesfully");
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

        public async Task<DTO_Result<Product>> UpdateProductAsync(Guid guid, DTO_Product dtoProduct)
        {
            var target = await context.Products.FirstOrDefaultAsync(p => p.Id == guid);

            if (target == null)            
                return new DTO_Result<Product>(false, "Product not found");
            

            try
            {
                target.ProductName = dtoProduct.ProductName;
                target.Description = dtoProduct.Description;
                target.Price = dtoProduct.Price;
                target.Discount = dtoProduct.Discount;

                //context.Entry(target).CurrentValues.SetValues(product);

                await context.SaveChangesAsync();
                return new DTO_Result<Product>(true, "Product update succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return new DTO_Result<Product>(false, $"Error during update: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsBySPAsync(int pageNumber, int rowPerPage)
        {
            using (var connection = new SqlConnection(context.Database.GetConnectionString()))
            {
                var procedure = "sp_GetProductsPaged";
                var values = new { PageNumber = pageNumber, RowsPerPage = rowPerPage };

                var result = await connection.QueryAsync<Product>(
                    procedure,
                    values,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return result;
            }
        }
    }
}
