using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.Model
{
    public  class Choice:AuditableEntity
    {
        public string Text { get; set; }
        public bool IsCorectChoice { get; set; }

        [ForeignKey("Question")]

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }


    }
}
