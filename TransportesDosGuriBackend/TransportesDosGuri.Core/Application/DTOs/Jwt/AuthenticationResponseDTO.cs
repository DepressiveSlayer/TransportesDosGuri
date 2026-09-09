namespace TransportesDosGuri.Core.Application.DTOs.Jwt
{
    public class AuthenticationResponseDTO
    {
        public string? PersonName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Token { get; set; } = string.Empty;

        public DateTime TokenExpiration { get; set; }

        public string? RefreshToken { get; set; } = string.Empty;

        public DateTime RefreshTokenExpirationDateTime { get; set; }
    }
}
