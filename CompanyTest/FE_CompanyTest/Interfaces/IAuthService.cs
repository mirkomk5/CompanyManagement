using DTO_CompanyTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE_CompanyTest.Interfaces
{
    public interface IAuthService
    {
        Task<DTO_AuthResponse> LoginAsync(DTO_AuthRequest dto_auth);
        Task<DTO_AuthResponse> RegisterAsync(DTO_RegisterRequest dto_register);
    }
}
