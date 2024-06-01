using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using U22552792_INF354_HW03_Backend.Models;
using U22552792_INF354_HW03_Backend.Models.IRepositories;

namespace U22552792_INF354_HW03_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticationController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

            [HttpPost("registerUser")]
            public async Task<IActionResult> Register(User user)
            {
                try
                {
                    var registeredUser = await _authRepository.RegisterUserAsync(user.Email, user.Password);
                    return Ok(registeredUser);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        [HttpPost("loginUser")]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var loggedInUser = await _authRepository.LoginAsync(user.Email, user.Password);

                if (loggedInUser == null)
                    return Unauthorized("Invalid credentials");

                return Ok(loggedInUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
