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

            if (!result.Success)
                return BadRequest(new { message = result.ErrorMessage });

            return Ok(result);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile([FromHeader(Name = "Authorization")] string authHeader)
        {
            var result = await _userService.Profile(authHeader ?? "");

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }
    }
}