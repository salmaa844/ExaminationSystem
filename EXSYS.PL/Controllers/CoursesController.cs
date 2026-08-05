using EXSYS.BLL.Service;
using EXSYS.DAL.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace EXSYS.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        [HttpPost("CreateCourse")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseRequeste request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var res = await _courseService.CreateCourseAsync(request, userId);

            return Ok();
        }

        [HttpDelete("DeleteCourse/{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteCourse([FromRoute]int id)
        {
            var result = await _courseService.DeleteCourse(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpGet("GetAllCourses")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> GetAllCourses([FromQuery] CourseFilterRequest request)
        {
            var result = await _courseService.GetAllCoursesAsync(request);
            return Ok(result);
        }
        [HttpGet("GetCourseById/{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> GetCourseById([FromRoute]int id)
        {
            var result = await _courseService.GetCourseiesAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("UpdateCourse/{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> UpdateCourse([FromRoute]int id, [FromBody] CourseUpdateRequest request)
        {
            var result = await _courseService.UpdateCourseAsync(id, request);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
