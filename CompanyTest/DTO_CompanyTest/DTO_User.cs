using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_CompanyTest
{
    public class DTO_User
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateOnly? RegistrationDate { get; set; }
        public string? Address { get; set; }
    }
}
