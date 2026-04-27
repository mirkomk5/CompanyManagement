using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_OrderTable
    {
        public string OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerFullname { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }
    }
}
