
namespace DTO_CompanyTest
{
    public class DTO_ClaimsTable
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
