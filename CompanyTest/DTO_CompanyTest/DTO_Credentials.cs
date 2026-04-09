using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_Credentials
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Password { get; set; }
        public string? Address { get; set; }
    }
}
