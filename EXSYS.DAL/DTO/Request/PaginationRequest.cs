using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class PaginationRequest
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 5;
        public string? Search { get; set; }
    }
}
