using EXSYS.BLL.Service;
using EXSYS.DAL.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EXSYS.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            this._examService = examService;
        }


        [HttpPost("CreateExam")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> CreateExam([FromBody] AddExamRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }
            await _examService.CreateExamAsync(request, userId);
            return Ok();
        }
        [HttpGet("GetAllExams")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> GetAllExams([FromQuery] ExamFilterRequest request)
        {
            var result = await _examService.GetAllExamsAsync(request);
            return Ok(result);
        }
        [HttpDelete("DeleteExam/{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> DeleteExam([FromRoute] int id)
        {
            var result = await _examService.DeleteExamAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("GetExamById/{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> GetExamById([FromRoute] int id)
        {
            var result = await _examService.GetExamByIdAsync(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("UpdateExam/{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int id, [FromBody] ExamUpdateRequest request)
        {
            var result = await _examService.UpdateExamAsync(id, request);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
