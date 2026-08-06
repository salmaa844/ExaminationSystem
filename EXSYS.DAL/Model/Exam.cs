using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
   
    public class Exam : AuditableEntity
    {
        public string Name { get; set; }

        public ExamType Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationInMinutes { get; set; }

        public decimal TotalMark { get; set; }

        public ExamStatus Status { get; set; } = ExamStatus.Draft;

        

        public int CourseId { get; set; }


        // Navigation Properties

        public Course Course { get; set; }


        public ICollection<ExamStudent> ExamStudents { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
