
namespace DTO_CompanyTest
{
    /// <summary>
    /// Classe di risposta all'autenticazione
    /// </summary>
    public class DTO_AuthResponse
    {
        public required Guid UserId { get; set; }
        public required string TokenId { get; set; }
    }
}
