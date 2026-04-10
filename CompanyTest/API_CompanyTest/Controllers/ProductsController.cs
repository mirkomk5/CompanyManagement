using API_CompanyTest.Services;
using DTO_CompanyTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_CompanyTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("get-all")]  
        public async Task<IActionResult> GetAllProducts()
        {
            var adminCheck = IsValidAdminLevel(1);
            if (!adminCheck.state)
                return StatusCode(403, adminCheck.message);

            var result = await service.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromBody]DTO_Product product)
        {
            var adminCheck = IsValidAdminLevel(1);
            if (!adminCheck.state)
                return StatusCode(403, adminCheck.message);

            var result = await service.CreateProductAsync(product);
            return Ok(result);
        }

        [HttpPost]
        [Route("create-by-sp")]
        public async Task<IActionResult> CreateProductBySP([FromBody] DTO_Product product)
        {
            var adminCheck = IsValidAdminLevel(1);
            if (!adminCheck.state)
                return StatusCode(403, adminCheck.message);

            var result = await service.SP_CreateProductAsync(product);
            return Ok(result);
        }


        private (bool state, string message) IsValidAdminLevel(int requiredLevel)
        {
            if (!int.TryParse(User.FindFirst(Miscellanous.Constants.AdminLevel)?.Value, out var result))
                return (false, "Invalid token: cannot read admin level");

            if (result < requiredLevel)
                return (false, "Access denied: insufficient permissions");
            return (true, "Access granted");
        }
    }
}
