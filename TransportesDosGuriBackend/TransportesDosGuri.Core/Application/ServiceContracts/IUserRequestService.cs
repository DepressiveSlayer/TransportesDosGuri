using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IUserRequestService
    {
        Task<IEnumerable<UserRequestDTO>> GetAllAsync();

        Task<UserRequestDTO?> GetByIdAsync(long id);

        Task<UserRequestDTO> CreateAsync(UserRequestDTO userRequest);

        Task<bool> UpdateAsync(long id, UserRequestDTO userRequest);

        Task<bool> DeleteAsync(long id);

        Task<UserRequestDTO> CreateWithPaymentAsync(UserRequestDTO userRequest);
    }
}
