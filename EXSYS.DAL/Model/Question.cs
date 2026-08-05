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


        // Course
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }


        // Instructor
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }


        // Exams that contain this question
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
            = new List<ExamQuestion>();


        // Students answers
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
            = new List<StudentAnswer>();
    }
}
