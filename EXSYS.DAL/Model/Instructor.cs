using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
   
    public class Instructor : AuditableEntity
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Exam> Exams { get; set; } 
    }
}
