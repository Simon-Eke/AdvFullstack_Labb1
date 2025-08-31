using AdvFullstack_Labb1.Models.DTOs;
using AdvFullstack_Labb1.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvFullstack_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginAdmin)
        {
            var newLogin = await _service.LoginAsync(loginAdmin.Username, loginAdmin.Password);

            if (newLogin == null)
                return BadRequest();

            return Ok(newLogin);
        }
    }
}
