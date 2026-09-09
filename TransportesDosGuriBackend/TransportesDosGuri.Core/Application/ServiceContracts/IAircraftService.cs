using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IAircraftService
    {
        Task<IEnumerable<AircraftDTO>> GetAllAsync();

        Task<AircraftDTO?> GetByIdAsync(long id);

        Task<AircraftDTO> CreateAsync(AircraftDTO aircraft);

        Task<bool> UpdateAsync(long id, AircraftDTO aircraft);

        Task<bool> DeleteAsync(long id);
    }
}
