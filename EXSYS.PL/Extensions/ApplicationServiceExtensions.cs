using EXSYS.BLL.Service;
using EXSYS.DAL.Repositry;
using EXSYS.DAL.Utils;

namespace EXSYS.PL.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection Services,IConfiguration configuration)
        {
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            Services.AddScoped<ISeedData, RolesSeedData>();
            Services.AddScoped<IStudentRepositry, StudentRepositry>();
            Services.AddScoped<IInstructorRepositry, InstructorRepositry>();
            Services.AddTransient<IEmailSender, EmailSender>();
            Services.AddScoped<IExamService, ExamService>();
            Services.AddScoped<ICourseService, CourseService>();
            Services.AddScoped<IExamRepositry, ExamRepositry>();
            Services.AddScoped<ICourseRepositry, CourseRepositry>();
            return Services;
        }
    }
}
