using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Responce
{
    public class ExamResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ExamType Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationInMinutes { get; set; }

        public decimal TotalMark { get; set; }

        public ExamStatus Status { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }
    }
}
