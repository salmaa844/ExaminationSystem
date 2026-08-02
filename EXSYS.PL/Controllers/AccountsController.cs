using EXSYS.BLL.Service;
using EXSYS.DAL.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXSYS.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountsController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authenticationService.RegisterAsync(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authenticationService.LoginAsync(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string userId)
        {
            var response = await _authenticationService.ConfirmEmailAsync(token, userId);
            if (!response)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("SendCode")]
        public async Task<IActionResult> ResetPassword(ForgotPasswordRequest request)
        {
            var response = await _authenticationService.RequestPasswordResetAsync(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassswordRequest request)
        {
            var response = await _authenticationService.ResetPassswordAsync(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut("change-role")]
        public async Task<IActionResult> ChangeRole(ChangeRoleRequest request)
        {
            var result = await _authenticationService.ChangeRoleAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
