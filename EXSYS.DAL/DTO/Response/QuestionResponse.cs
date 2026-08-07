using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Response
{
    public class QuestionResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public QuestionType Type { get; set; }

        public QuestionLevel Level { get; set; }

        public decimal Mark { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
