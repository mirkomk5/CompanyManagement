using DTO_CompanyTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE_CompanyTest.Interfaces
{
    public interface IProductService
    {
        Task<List<DTO_Product>> GetProductsAsync(string token);
    }
}
