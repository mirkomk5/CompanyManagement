using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_Order
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public string? Notes { get; set; }
    }
}
