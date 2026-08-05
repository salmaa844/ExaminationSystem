using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class CourseUpdateRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? Hours { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
