using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class QuestionFilterRequest: PaginationRequest
    {
        public string? Title { get; set; }

        public QuestionType? Type { get; set; }

        public QuestionLevel? Level { get; set; }

        public int? CourseId { get; set; }

        public decimal? MinMark { get; set; }

        public decimal? MaxMark { get; set; }
    }
}
