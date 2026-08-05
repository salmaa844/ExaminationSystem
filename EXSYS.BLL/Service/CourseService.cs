using Azure.Core;
using EXSYS.BLL.Extentions;
using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Response;
using EXSYS.DAL.Model;
using EXSYS.DAL.Repositry;
using Mapster;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EXSYS.BLL.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepositry _courseRepositry;

        public CourseService(ICourseRepositry courseRepositry)
        {
            this._courseRepositry = courseRepositry;
        }
        public async Task<bool> CreateCourseAsync(CourseRequeste requeste, string userId)
        {
            var existingCourse = await _courseRepositry.GetOne(c => c.Name == requeste.Name);

            if (existingCourse != null)
            {
                throw new InvalidOperationException("Course already exists");
            }

            var course = requeste.Adapt<Course>();

            course.CreatedById = userId;
            course.CreatedOn = DateTime.UtcNow;

            var result = await _courseRepositry.CreateAsync(course);

            if (result == null)
            {
                return false;
            }

            return true;
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var existingCourse = await _courseRepositry.GetOne(c => c.Id == id);
            if (existingCourse == null)
            {
                throw new Exception("Course not found");
                
            }
            var result = await _courseRepositry.DeleteAsync(existingCourse);
            if (!result)
            {
                throw new Exception("Course not deleted");
               
            }
            return true;
        }

        public async Task<PaginationResponse<CourseResponse>> GetAllCoursesAsync(CourseFilterRequest request)
        {
            var query = _courseRepositry.GetQueryable(
                null,
                new string[]
                {
            nameof(Course.CreatedBy)
                });


            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(c => c.Name.Contains(request.Name));
            }


            if (request.MinHours.HasValue)
            {
                query = query.Where(c => c.Hours >= request.MinHours.Value);
            }


            if (request.MaxHours.HasValue)
            {
                query = query.Where(c => c.Hours <= request.MaxHours.Value);
            }


            if (!string.IsNullOrEmpty(request.CreatedById))
            {
                query = query.Where(c => c.CreatedById == request.CreatedById);
            }


            var paginationResponse = await query.ToPaginationAsync(
                request.Page,
                request.Limit
            );


            return new PaginationResponse<CourseResponse>
            {
                Data = paginationResponse.Data.Adapt<List<CourseResponse>>(),
                TotalCount = paginationResponse.TotalCount,
                Page = paginationResponse.Page,
                Limit = paginationResponse.Limit
            };
        }

        public async Task<CourseResponse> GetCourseiesAsync(Expression<Func<Course, bool>> filter)
        {
            var course = await _courseRepositry.GetOne(filter, new string[]
            {
                nameof(Course.CreatedBy)
            });
            return course.Adapt<CourseResponse>();
        }

        public async Task<bool> UpdateCourseAsync(int id, CourseUpdateRequest request)
        {
            var course = await _courseRepositry.GetOne(c => c.Id == id);

            if (course == null)
                return false;


            if (!string.IsNullOrEmpty(request.Name))
                course.Name = request.Name;


            if (!string.IsNullOrEmpty(request.Description))
                course.Description = request.Description;


            if (request.Hours.HasValue)
                course.Hours = request.Hours.Value;

            if (request.IsDeleted.HasValue)
                course.IsDeleted = request.IsDeleted.Value;


            course.UpdatedOn = DateTime.UtcNow;


            return await _courseRepositry.UpdateAsync(course);
        }
    }
}
