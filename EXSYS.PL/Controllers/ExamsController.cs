using EXSYS.BLL.Service;
using EXSYS.DAL.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddExamRequest request)
        {
            var exam = _examService.CreateExamAsync(request);
            return Ok(exam);

        }

    }
}
