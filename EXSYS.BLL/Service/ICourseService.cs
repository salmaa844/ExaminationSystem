using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Response;
using EXSYS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.BLL.Service
{
    public interface ICourseService
    {
        Task<bool> CreateCourseAsync(CourseRequeste requeste, string userId);
        Task<PaginationResponse<CourseResponse>> GetAllCoursesAsync(CourseFilterRequest request);
        Task<CourseResponse> GetCourseiesAsync(Expression<Func<Course, bool>> filter);
        Task<bool> DeleteCourse(int id);
        Task<bool> UpdateCourseAsync(int id, CourseUpdateRequest request);
    }
}
