using TransportesDosGuri.Core.Application.DTOs.Identity;
using TransportesDosGuri.Core.Application.DTOs.Jwt;

namespace TransportesDosGuri.Core.Application.ServiceContracts.Identity
{
    public interface IIdentityService
    {
        Task<(bool Success, IEnumerable<string> Errors, long? UserId)> RegisterAsync(RegisterDTO register);
        Task<(bool Success, IEnumerable<string> Errors, long? UserId, AuthenticationResponseDTO? Jwt)> LoginAsync(LoginDTO login);
        Task<UserProfileResponseDTO?> GetByIdAsync(long id);
        Task<IEnumerable<UserProfileResponseDTO>> GetAllAsync();
        Task<(bool Success, IEnumerable<string> Errors)> UpdateAsync(long id, UpdateDTO update);
        Task<(bool Success, IEnumerable<string> Errors)> DeleteAsync(long id);
        Task<(bool Success, AuthenticationResponseDTO? Response, IEnumerable<string> Errors)> GenerateNewAccessTokenAsync(TokenModelDTO tokenModel);
        Task<(bool Success, IEnumerable<string> Errors)> LogoutAsync(TokenModelDTO tokenModel);

    }
}
