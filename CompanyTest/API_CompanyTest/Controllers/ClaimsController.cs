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
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService service;

        public ClaimsController(IClaimsService service)
        {
            this.service = service;
        }

        [HttpPost("claims-table")]
        public async Task<ActionResult<List<DTO_ClaimsTable>>> GetClaimsTable()
        {
            var adminCheck = IsValidAdminLevel(1);
            if (!adminCheck.state)
                return StatusCode(401, adminCheck.message);

            var result = await service.GetClaimsTable();
            if(result == null || result.Count == 0)
                return NotFound("No claims found.");
            return Ok(result);
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
