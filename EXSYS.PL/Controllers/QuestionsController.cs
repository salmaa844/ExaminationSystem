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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService) {
            this._questionService = questionService;
        }
        [HttpPost("CreateQuestion")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            await _questionService.CreateQuestionAsync(request, userId);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles ="Instructor")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return Ok();
        }
        [HttpGet("GetQuestion")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> GetQuestion([FromQuery] QuestionFilterRequest request)
        {
            var result = await _questionService.GetAllQuestionsAsync(request);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpPut("UpdateQuestion/{id}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionRequest request)
        {
            await _questionService.UpdateQuestionAsync(id, request);
            return Ok();
        }
    }
}
