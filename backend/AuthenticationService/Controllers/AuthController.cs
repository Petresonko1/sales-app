using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Grpc.Net.Client;
using YourNamespace.Protos; // Adjust the namespace according to your project structure

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService.AuthServiceClient _authServiceClient;

        public AuthController(AuthService.AuthServiceClient authServiceClient)
        {
            _authServiceClient = authServiceClient;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authServiceClient.RegisterAsync(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authServiceClient.LoginAsync(request);
            return Ok(response);
        }
    }
}