using API_CompanyTest.Services;
using AutoMapper;
using BE_CompanyTest.Models;
using DTO_CompanyTest;
using Microsoft.AspNetCore.Mvc;

namespace API_CompanyTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] DTO_User userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userService.CreateUserAsync(userDto);
            return Ok(result);
        }
    }
}
