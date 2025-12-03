using ktpm_backend_master.DTO;
using ktpm_backend_master.Services;
using Microsoft.AspNetCore.Mvc;

namespace ktpm_backend_master.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly InterfaceUserService _userService;

        public UserController(InterfaceUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.Login(request);

            if (result == null)
                return Unauthorized("Invalid email or password");

            return Ok(result);
        }
    }
}