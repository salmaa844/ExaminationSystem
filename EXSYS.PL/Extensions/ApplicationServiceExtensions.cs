using EXSYS.BLL.Service;
using EXSYS.DAL.Utils;

namespace EXSYS.PL.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection Services,IConfiguration configuration)
        {
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            Services.AddScoped<ISeedData, RolesSeedData>();
            Services.AddTransient<IEmailSender, EmailSender>();

            return Services;
        }
    }
}
