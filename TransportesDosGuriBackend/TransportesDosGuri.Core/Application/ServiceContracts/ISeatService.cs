using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatDTO>> GetAllAsync();

        Task<SeatDTO?> GetByIdAsync(long id);

        Task<SeatDTO> CreateAsync(SeatDTO seat);

        Task<bool> UpdateAsync(long id, SeatDTO seat);

        Task<bool> DeleteAsync(long id);
    }
}
