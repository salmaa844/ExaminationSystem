using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Responce
{
    public class RegisterResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public List<string>? Error { get; set; }
    }
}
