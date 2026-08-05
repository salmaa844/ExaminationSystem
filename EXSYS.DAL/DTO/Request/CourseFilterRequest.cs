using EXSYS.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class CourseFilterRequest : PaginationRequest
    {
        public string? Name { get; set; }

        public int? MinHours { get; set; }

        public int? MaxHours { get; set; }

        public string? CreatedById { get; set; }
        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }
    }
}
