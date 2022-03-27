using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTO;

namespace CompanyEmployees.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public TokenController(IAuthenticationService service)
        {
            _authService = service;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var token = await _authService.RefreshToken(tokenDto);

            return Ok(token);
        }
    }
}
