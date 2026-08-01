using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    public class Question : AuditableEntity
    {
        public string Title { get; set; }
        public QuestionLevel Level { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }


        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        
        public Instructor Instructor { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }


    }
}
