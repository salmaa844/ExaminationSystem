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

namespace EXSYS.BLL.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepositry _examRepositry;

        public ExamService(IExamRepositry examRepositry)
        {
            this._examRepositry = examRepositry;
        }
        public async Task CreateExamAsync(AddExamRequest request)
        {
            var exam =  request.Adapt<Exam>();
            await _examRepositry.CreateAsync(exam);

        }

        public Task<bool> DeleteExamAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResponse<ExamResponse>> GetAllExamsAsync(ExamFilterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ExamResponse> GetExamByIdAsync(Expression<Func<Exam, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExamAsync(int id, ExamUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
