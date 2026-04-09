using API_CompanyTest.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_CompanyTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private ITokenService tokenService;
        private IMapper mapper;

        public AuthController(ITokenService tokenService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var token = tokenService.CreateToken(username, password);
            return Ok(token);
        }
    }
}
