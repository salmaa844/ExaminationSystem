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
    public interface IQuestionService
    {
        Task CreateQuestionAsync(QuestionRequest request, string userId);

        Task UpdateQuestionAsync(int id, UpdateQuestionRequest request);

        Task<bool> DeleteQuestionAsync(int id);

        Task<QuestionResponse> GetQuestionByIdAsync(Expression<Func<Question, bool>> filter);

        Task<PaginationResponse<QuestionResponse>> GetAllQuestionsAsync(QuestionFilterRequest request);

    }
}
