using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTO;

namespace CompanyEmployees.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService service)
        {
            _authService = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForReg)
        {
            var result = await _authService.RegisterUser(userForReg);
            if (!result.Succeeded)
                return BadRequest();

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuth)
        {
            if (!await _authService.ValidateUser(userForAuth))
                return Unauthorized();

            var tokenDto = await _authService.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
    }
}