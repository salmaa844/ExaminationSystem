using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class ChangeRoleRequest
    {
        public string UserId { get; set; }
        public string NewRoleName { get; set; }
    }
}
