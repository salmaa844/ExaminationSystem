using EXSYS.BLL.Extentions;
using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Response;
using EXSYS.DAL.Enums;
using EXSYS.DAL.Model;
using EXSYS.DAL.Repositry;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.BLL.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepositry _questionRepositry;
        private readonly ICourseRepositry _courseRepositry;

        public QuestionService(IQuestionRepositry questionRepositry,ICourseRepositry courseRepositry)
        {
            this._questionRepositry = questionRepositry;
            this._courseRepositry = courseRepositry;
        }
        public async Task CreateQuestionAsync(QuestionRequest request, string userId)
        {
            var existingCourse = await _courseRepositry.GetOne(c => c.Id == request.CourseId);

            if (existingCourse == null)
                throw new Exception("Course not found.");

            if (request.Mark <= 0)
                throw new Exception("Mark must be greater than zero.");

            if (request.Type == QuestionType.MultipleChoice)
            {
                if (request.Choices == null || request.Choices.Count < 2)
                    throw new Exception("Multiple choice question needs at least two choices.");

                if (request.Choices.Count(x => x.IsCorrectChoice) != 1)
                    throw new Exception("Multiple choice question must have one correct choice.");
            }


            var question = request.Adapt<Question>();
            question.CreatedById = userId;


            if (request.Type == QuestionType.TrueFalse)
            {
                question.Choices = new List<Choice>
                {
                    new Choice
                    {
                        Text = "True",
                        IsCorectChoice = true,
                        CreatedById = userId
                    },
                    new Choice
                    {
                        Text = "False",
                        IsCorectChoice = false,
                        CreatedById = userId
                    }
                };
            }
            else
            {
                foreach (var choice in question.Choices)
                {
                    choice.CreatedById = userId;
                }
            }
            await _questionRepositry.CreateAsync(question);
        }
        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var existingQuestion = await  _questionRepositry.GetOne(c => c.Id == id);
            if (existingQuestion == null)
            {
                throw new Exception("Course not found");

            }
            var result = await _questionRepositry.DeleteAsync(existingQuestion);
            if (!result)
            {
                throw new Exception("Course not deleted");

            }
            return true;
        }

        public async Task<PaginationResponse<QuestionResponse>> GetAllQuestionsAsync(QuestionFilterRequest request)
        {
            var query = _questionRepositry.GetQueryable(
                null,
                new string[]
                {
            nameof(Question.CreatedBy),
            nameof(Question.Course)
                });


            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(q => q.Title.Contains(request.Title));
            }


            if (request.Type.HasValue)
            {
                query = query.Where(q => q.Type == request.Type.Value);
            }


            if (request.Level.HasValue)
            {
                query = query.Where(q => q.Level == request.Level.Value);
            }


            if (request.CourseId.HasValue)
            {
                query = query.Where(q => q.CourseId == request.CourseId.Value);
            }


            if (request.MinMark.HasValue)
            {
                query = query.Where(q => q.Mark >= request.MinMark.Value);
            }


            if (request.MaxMark.HasValue)
            {
                query = query.Where(q => q.Mark <= request.MaxMark.Value);
            }


            var paginationResponse = await query.ToPaginationAsync(
                request.Page,
                request.Limit
            );


            return new PaginationResponse<QuestionResponse>
            {
                Data = paginationResponse.Data.Adapt<List<QuestionResponse>>(),
                TotalCount = paginationResponse.TotalCount,
                Page = paginationResponse.Page,
                Limit = paginationResponse.Limit
            };
        }
        public Task<QuestionResponse> GetQuestionByIdAsync(Expression<Func<Question, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateQuestionAsync(int id, UpdateQuestionRequest request)
        {
            var question = await _questionRepositry.GetOne(q => q.Id == id);

            if (question == null)
            {
                throw new Exception("Question not found.");
            }


            if (!string.IsNullOrEmpty(request.Title))
                question.Title = request.Title;


            if (request.Type.HasValue)
                question.Type = request.Type.Value;


            if (request.Level.HasValue)
                question.Level = request.Level.Value;


            if (request.Mark.HasValue)
                question.Mark = request.Mark.Value;


            await _questionRepositry.UpdateAsync(question);
        }
    }
}
