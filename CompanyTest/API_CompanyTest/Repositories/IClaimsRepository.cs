using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace API_CompanyTest.Repositories
{
    public interface IClaimsRepository
    {
        Task<Claim> GetClaimById(Guid id);
        Task<List<DTO_ClaimsTable>> GetClaimsTable();
    }

    public class ClaimsRepository(CompanyTestContext context) : IClaimsRepository
    {
        public async Task<Claim> GetClaimById(Guid id)
        {
            var result = await context.Claims.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<List<DTO_ClaimsTable>> GetClaimsTable()
        {

            var query = context.Claims.Select(c => new DTO_ClaimsTable
            {
                Id = c.Id,
                CustomerName = $"{c.Order.Customer.Name} {c.Order.Customer.Surname}",
                CustomerEmail = c.Order.Customer.Email ?? "",
                CreatedAt = c.CreatedAt,
                Message = c.Message,
                ProductName = c.Order.Product.ProductName,
                Price = c.Order.Product.Price
            });
            return query.ToList();
        }
    }
}
