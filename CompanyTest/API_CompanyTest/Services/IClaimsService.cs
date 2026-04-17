using API_CompanyTest.Repositories;
using DTO_CompanyTest;

namespace API_CompanyTest.Services
{
    public interface IClaimsService
    {
        Task<DTO_ClaimsTable> GetClaimById(Guid id);
        Task<List<DTO_ClaimsTable>> GetClaimsTable();
    }

    public class ClaimsService(IClaimsRepository claimsRepo) : IClaimsService
    {
        public Task<DTO_ClaimsTable> GetClaimById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DTO_ClaimsTable>> GetClaimsTable()
        {
            return await claimsRepo.GetClaimsTable();
        }
    }
}
