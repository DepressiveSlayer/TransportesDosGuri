using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDTO>> GetAllAsync();

        Task<ScheduleDTO?> GetByIdAsync(long id);

        Task<ScheduleDTO> CreateAsync(ScheduleDTO schedule);

        Task<bool> UpdateAsync(long id, ScheduleDTO schedule);

        Task<bool> DeleteAsync(long id);
    }
}
