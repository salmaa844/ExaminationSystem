using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    
    public class Exam :AuditableEntity
    {
        public string Name { get; set; }
        public ExamType Type { get; set; }
        public DateTime Date { get; set; }

        public int DurationInMinutes { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }


        //Navigation Properties

        public Course Course { get; set; }

        public Instructor Instructor { get; set; }

        public ICollection<ExamStudent> ExamStudents { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }



    }
}
