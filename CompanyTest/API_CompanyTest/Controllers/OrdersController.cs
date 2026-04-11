using API_CompanyTest.Services;
using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_CompanyTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] DTO_Order order)
        {
            var adminCheck = IsValidAdminLevel(1);
            if (!adminCheck.state)
                return StatusCode(401, adminCheck.message);

            var result = await service.CreateOrderAsync(order);
            return result.State ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var adminCheck = IsValidAdminLevel(1);
            if (!adminCheck.state)
                return StatusCode(401, adminCheck.message);

            var result = await service.DeleteOrderAsync(id);
            return result.State ? Ok(result.Message) : BadRequest(result.Message);
        }

        // ***********

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
