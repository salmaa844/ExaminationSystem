using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class QuestionRequest
    {
        public string Title { get; set; }

        public QuestionType Type { get; set; }

        public QuestionLevel Level { get; set; }

        public decimal Mark { get; set; }

        public int CourseId { get; set; }

        public List<AddChoiceRequest> Choices { get; set; } = new();
    }
}
