using Microsoft.AspNetCore.Mvc;
using creatus_backend.Dtos.Request;
using creatus_backend.Services;

namespace creatus_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService, IJwtService jwtService)
        {
            _logger = logger;
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _authService.Authenticate(loginRequest.Email, loginRequest.Password);
                var token = _jwtService.GenerateToken(user);

                return Ok(new { Token = token });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
