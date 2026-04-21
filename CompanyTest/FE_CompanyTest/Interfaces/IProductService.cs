using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace FE_CompanyTest.Interfaces
{
    public interface IProductService
    {
        Task<List<DTO_Product>> GetProductsAsync(string token, int pageNumber, int rowPerPage);
        Task<(bool status, string message)> CreateProductAsync(DTO_Product product, string tokenId);
        Task<DTO_Result<Product?>> UpdateProductAsync(DTO_Product product, string tokenId);
    }
}
