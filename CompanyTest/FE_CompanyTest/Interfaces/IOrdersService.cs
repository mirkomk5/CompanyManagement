using DTO_CompanyTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE_CompanyTest.Interfaces
{
    public interface IOrdersService
    {
        Task<List<DTO_OrderTable>> GetOrdersAsync(string tokenId, int from, int amount);
    }
}
