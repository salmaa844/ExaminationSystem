using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    public class ExamStudent
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [ForeignKey("Exam")]
        public int ExamID { get; set; }
        public decimal? FinalGrade { get; set; }

        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}
