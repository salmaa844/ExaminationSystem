using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.BLL.Service
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<bool> ConfirmEmailAsync(string token, string id);
        Task<ForgotPasswordResponse> RequestPasswordResetAsync(ForgotPasswordRequest request);
        Task<ResetPassswordResponse> ResetPassswordAsync(ResetPassswordRequest request);
        Task<ChangeRoleResponse> ChangeRoleAsync(ChangeRoleRequest request);

    }
}
