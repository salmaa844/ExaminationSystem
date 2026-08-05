using EXSYS.DAL.Data;
using EXSYS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Repositry
{
    public class ExamRepositry : GenericRepository<Exam>, IExamRepositry
    {
        public ExamRepositry(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
