using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAllAsync();

        Task<ReservationDTO?> GetByIdAsync(long id);

        Task<ReservationDTO> CreateAsync(ReservationDTO reservation);

        Task<bool> UpdateAsync(long id, ReservationDTO reservation);

        Task<bool> DeleteAsync(long id);
    }
}
