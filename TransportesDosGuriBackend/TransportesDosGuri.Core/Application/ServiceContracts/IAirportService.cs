using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IAirportService
    {
        Task<IEnumerable<AirportDTO>> GetAllAsync();

        Task<AirportDTO?> GetByIdAsync(long id);

        Task<AirportDTO> CreateAsync(AirportDTO airport);

        Task<bool> UpdateAsync(long id, AirportDTO airport);

        Task<bool> DeleteAsync(long id);
    }
}
