using EXSYS.DAL.Data;
using EXSYS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Repositry
{
    public class InstructorRepositry : GenericRepository<Instructor>, IInstructorRepositry
    {
        public InstructorRepositry(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
