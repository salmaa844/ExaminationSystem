using EXSYS.BLL.Extentions;
using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Responce;
using EXSYS.DAL.DTO.Response;
using EXSYS.DAL.Model;
using EXSYS.DAL.Repositry;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EXSYS.BLL.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepositry _examRepository;
        private readonly ICourseRepositry _courseRepository;

        public ExamService(IExamRepositry examRepositry, ICourseRepositry courseRepository)
        {
            this._examRepository = examRepositry;            this._courseRepository = courseRepository;

        }
        public async Task CreateExamAsync(AddExamRequest request, string userId)
        {
            var course = await _courseRepository.GetOne(c => c.Id == request.CourseId);

            if (course == null)
                throw new Exception("Course not found.");

            var hasConflict = _examRepository.GetQueryable(e =>
                    e.CreatedById == userId &&
                    request.StartDate < e.EndDate &&
                    request.EndDate > e.StartDate
                ).Any();

            if (hasConflict)
                throw new Exception("You already have an exam scheduled during this time.");

            var exam = request.Adapt<Exam>();

            exam.CreatedById = userId;
            exam.CourseId = course.Id;

            await _examRepository.CreateAsync(exam);
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
            var existingExam = await _examRepository.GetOne(e => e.Id == id);

            if (existingExam == null)
                return false;

            await _examRepository.DeleteAsync(existingExam);

            return true;
        }

        public async Task<PaginationResponse<ExamResponse>> GetAllExamsAsync(ExamFilterRequest request)
        {
            var query = _examRepository.GetQueryable(null, new string[]
            {
                 nameof(Exam.Course)
            });

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type.Value);

            if (request.CourseId.HasValue)
                query = query.Where(x => x.CourseId == request.CourseId.Value);

            if (request.StartDate.HasValue)
                query = query.Where(x => x.StartDate >= request.StartDate.Value);

            if (request.EndDate.HasValue)
                query = query.Where(x => x.EndDate <= request.EndDate.Value);

            var paginationResponse = await query.ToPaginationAsync(
               request.Page,
               request.Limit
           );


            return new PaginationResponse<ExamResponse>
            {
                Data = paginationResponse.Data.Adapt<List<ExamResponse>>(),
                TotalCount = paginationResponse.TotalCount,
                Page = paginationResponse.Page,
                Limit = paginationResponse.Limit
            };
        }

        public async Task<ExamResponse> GetExamByIdAsync(Expression<Func<Exam, bool>> filter)
        {
            var exam = await _examRepository.GetOne(filter, new string[]
            {
                         nameof(Exam.Course)
            });

            if (exam == null)
                throw new Exception("Exam not found.");

            return exam.Adapt<ExamResponse>();
        }

        public async Task<bool> UpdateExamAsync(int id, ExamUpdateRequest request)
        {
            var exam = await _examRepository.GetOne(e => e.Id == id);
            if (exam == null) return false;

            if (request.Name != null)
                exam.Name = request.Name;

            if (request.Type.HasValue)
                exam.Type = request.Type.Value;

            if (request.StartDate.HasValue)
                exam.StartDate = request.StartDate.Value;

            if (request.EndDate.HasValue)
                exam.EndDate = request.EndDate.Value;

            if (request.DurationInMinutes.HasValue)
                exam.DurationInMinutes = request.DurationInMinutes.Value;

            if (request.TotalMark.HasValue)
                exam.TotalMark = request.TotalMark.Value;

            if (request.CourseId.HasValue)
                exam.CourseId = request.CourseId.Value;
            exam.UpdatedOn = DateTime.UtcNow;


            return await _examRepository.UpdateAsync(exam);
        }
    }
}
