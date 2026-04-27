
namespace DTO_CompanyTest
{
    /// <summary>
    /// Classe di risposta all'autenticazione
    /// </summary>
    public class DTO_AuthResponse
    {
        public required Guid UserId { get; set; }
        public required string TokenId { get; set; }
        public string? Message { get; set; }
        public bool? Success { get; set; } = false;

        public DTO_AuthResponse() { }

        public DTO_AuthResponse(Guid userId, string tokenId)
        {
            UserId = userId;
            TokenId = tokenId;
        }

        public DTO_AuthResponse(Guid userId, string tokenId, string message, bool success)
        {
            UserId = userId;
            TokenId = tokenId;
            Message = message;
            Success = success;
        }

    }
}
