using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_ResponseMessage
    {
        public bool State { get; set; }
        public string Message { get; set; } = null!;
        public DTO_ResponseMessage(bool state, string message)
        {
            State = state;
            Message = message;
        }
    }
}
