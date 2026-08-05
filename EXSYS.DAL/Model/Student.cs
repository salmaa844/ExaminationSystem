using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    public class Student : AuditableEntity
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<ExamStudent> ExamStudents { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
