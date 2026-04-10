using API_CompanyTest.Repositories;
using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Services
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(DTO_Product product);
        Task<bool> SP_CreateProductAsync(DTO_Product product);
        Task<bool> UpdateProductAsync(DTO_Product product);
        Task<bool> DeleteProductAsync(Guid id);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<DTO_Product>?> GetAllProductsAsync();
    }

    public class ProductService(IMapper mapper, IProductRepository productRepo) : IProductService
    {
        public async Task<bool> CreateProductAsync(DTO_Product product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            return await productRepo.CreateProductAsync(mappedProduct);
        }

        public async Task<bool> SP_CreateProductAsync(DTO_Product product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            return await productRepo.SP_CreateProductAsync(mappedProduct);
        } 

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            return await productRepo.DeleteProductAsync(id);
        }

        public async Task<IEnumerable<DTO_Product>?> GetAllProductsAsync()
        {
            var allProducts = await productRepo.GetAllProductsAsync();
            var mappedProducts = mapper.Map<IEnumerable<DTO_Product>>(allProducts);
            return mappedProducts;
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var product = await productRepo.GetProductByIdAsync(id);
            return product;
        }

        public async Task<bool> UpdateProductAsync(DTO_Product product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            var result = await productRepo.UpdateProductAsync(mappedProduct);
            return result;
        }
    }
}
