using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    public class StudentAnswer 
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int ExamID { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorect { get; set; }


        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Question Question { get; set; }


    }
}
