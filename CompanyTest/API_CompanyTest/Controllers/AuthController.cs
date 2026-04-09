using API_CompanyTest.Services;
using AutoMapper;
using DTO_CompanyTest;
using Microsoft.AspNetCore.Mvc;

namespace API_CompanyTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private ITokenService tokenService;
        private IMapper mapper;
        private IAuthenticationService authService;

        public AuthController(ITokenService tokenService, IAuthenticationService authService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.authService = authService;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] DTO_RegisterRequest credentials)
        {
            var task = await authService.RegisterAsync(credentials);
            if (task == null) return BadRequest("Something wrong during user profile creation");

            return Ok(task);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] DTO_AuthRequest request)
        {
            var task = await authService.LoginAsync(request);
            if(task == null) return BadRequest("Invalid email or password");
            return Ok(task);
        }
    }
}
