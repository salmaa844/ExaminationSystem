using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Responce;
using EXSYS.DAL.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.BLL.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager,IEmailSender emailSender,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration
            )
        {
            this._userManager = userManager;
            this._emailSender = emailSender;
            this._httpContextAccessor = httpContextAccessor;
            this._configuration = configuration;
        }
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var user = request.Adapt<ApplicationUser>();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Registration failed",
                    Error = result.Errors.Select(e => e.Description).ToList()
                };
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);//ما فيها داتا فقط لتأكد هل اليوزر وصل ل الصفحة بشكلل صحيح 
            token = Uri.EscapeDataString(token);


            var emailUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}" +
                $"://{_httpContextAccessor.HttpContext.Request.Host}" +
                $"/api/Accounts/ConfirmEmail?token={token}&userId={user.Id}";
            await _userManager.AddToRoleAsync(user,"Student");
            await _emailSender.SendEmailAsync(
                user.Email,
                "welcome",
                $"<h2>welcome {request.UserName}</h2>" +
                $"<a href='{emailUrl}'>Confirm Email</a>"
            );


            return new RegisterResponse
            {
                Message = "User registered successfully",
                Success = true
            };

        }
        
        public async Task<bool> ConfirmEmailAsync(string token, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null) return false;

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded) return false;
            return true;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return new LoginResponse() { Success = false, Message = "invalid email" };

            if (!await _userManager.IsEmailConfirmedAsync(user))
                return new LoginResponse() { Success = false, Message = "email not confirmed" };

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!result)
                return new LoginResponse() { Success = false, Message = "invalid email" };


            return new LoginResponse()
            {
                Success = true,
                Message = "success",
                AccessToken = await GenerateAccessToken(user)

            };
        }
        private async Task<string> GenerateAccessToken(ApplicationUser user)
        {
            var userClaims = new List<Claim>() {

                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email)

            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials
        );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public Task<ForgotPasswordResponse> RequestPasswordResetAsync(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResetPassswordResponse> ResetPassswordAsync(ResetPassswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
