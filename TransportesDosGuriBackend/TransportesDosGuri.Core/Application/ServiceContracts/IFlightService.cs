using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IFlightService
    {
        Task<IEnumerable<FlightDTO>> GetAllAsync();

        Task<FlightDTO?> GetByIdAsync(long id);

        Task<FlightDTO> CreateAsync(FlightDTO flight);

        Task<bool> UpdateAsync(long id, FlightDTO flight);

        Task<bool> DeleteAsync(long id);
    }
}
