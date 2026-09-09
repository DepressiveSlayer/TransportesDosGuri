using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllAsync();

        Task<Schedule?> GetByIdAsync(long id);

        Task AddAsync(Schedule schedule);

        Task UpdateAsync(Schedule schedule);

        Task DeleteAsync(long id);
    }
}
