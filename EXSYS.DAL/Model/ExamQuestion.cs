using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    public class ExamQuestion
    {
        public int Id { get; set; }

        public decimal Grade { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        //Navigation Properties
        public Exam Exam { get; set; }
        public Question Question { get; set; }


    }
}
