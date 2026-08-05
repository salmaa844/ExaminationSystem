using EXSYS.DAL.DTO.Request;
using EXSYS.DAL.DTO.Responce;
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
   
    public interface IExamService
    {
        Task CreateExamAsync(AddExamRequest request);

        Task<PaginationResponse<ExamResponse>> GetAllExamsAsync(ExamFilterRequest request);

        Task<ExamResponse> GetExamByIdAsync(Expression<Func<Exam, bool>> filter);

        Task<bool> UpdateExamAsync(int id, ExamUpdateRequest request);

        Task<bool> DeleteExamAsync(int id);
    }
   
}
