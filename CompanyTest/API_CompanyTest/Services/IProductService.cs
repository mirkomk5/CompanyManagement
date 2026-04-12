using API_CompanyTest.Repositories;
using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;

namespace API_CompanyTest.Services
{
    public interface IProductService
    {
        Task<DTO_ResponseMessage> CreateProductAsync(DTO_Product product);
        Task<DTO_ResponseMessage> SP_CreateProductAsync(DTO_Product product);
        Task<DTO_ResponseMessage> UpdateProductAsync(Guid id, DTO_Product dtoProduct);
        Task<DTO_ResponseMessage> DeleteProductAsync(Guid id);
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<DTO_Product>?> GetAllProductsAsync();
    }

    public class ProductService(IMapper mapper, IProductRepository productRepo) : IProductService
    {
        public async Task<DTO_ResponseMessage> CreateProductAsync(DTO_Product product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            var result = await productRepo.CreateProductAsync(mappedProduct);
            return result;
        }

        public async Task<DTO_ResponseMessage> SP_CreateProductAsync(DTO_Product product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            return await productRepo.SP_CreateProductAsync(mappedProduct);
        } 

        public async Task<DTO_ResponseMessage> DeleteProductAsync(Guid id)
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

        public async Task<DTO_ResponseMessage> UpdateProductAsync(Guid id, DTO_Product dtoProduct)
        {
            var result = await productRepo.UpdateProductAsync(id, dtoProduct);
            return result;
        }
    }
}
