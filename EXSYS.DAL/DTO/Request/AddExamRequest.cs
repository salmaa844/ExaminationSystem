using EXSYS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
   public class AddExamRequest
{
    public string Name { get; set; }

    public ExamType Type { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int DurationInMinutes { get; set; }

    public decimal TotalMark { get; set; }

    public int CourseId { get; set; }
}
}
