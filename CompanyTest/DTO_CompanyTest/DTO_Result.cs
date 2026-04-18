using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_Result<T>
    {
        public T? Data { get; set; }
        public bool State { get; set; }
        public string Message { get; set; } = null!;

        public DTO_Result(T data, bool state, string message)
        {
            Data = data;
            State = state;
            Message = message;
        }

        public DTO_Result(bool state, string message)
        {
            State = state;
            Message = message;
        }
    }
}
