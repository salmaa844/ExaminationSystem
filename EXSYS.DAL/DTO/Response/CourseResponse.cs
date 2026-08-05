using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Response
{
    public class CourseResponse
    {
        public int Course_Id { get; set; }

        public string UserCreated { get; set; }

        public int Hours { get; set; }
        public string Name { get; set; }
        
    }
}
