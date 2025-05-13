using Microsoft.AspNetCore.Mvc;
using UserService.Application.Abstractions;
using UserService.Application.DTOs;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterUsersController(IUserRegistrationService userRegistrationService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var userId = await userRegistrationService.RegisterUserAsync(request);
            return Ok(new { userId });
        }
    }
}