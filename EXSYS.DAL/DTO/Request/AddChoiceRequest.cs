using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSYS.DAL.DTO.Request
{
    public class AddChoiceRequest
    {
        public string Text { get; set; }

        public bool IsCorrectChoice { get; set; }
    }
}
