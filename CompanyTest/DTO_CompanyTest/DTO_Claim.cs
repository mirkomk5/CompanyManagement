using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_Claim
    {
        public Guid OrderId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}
