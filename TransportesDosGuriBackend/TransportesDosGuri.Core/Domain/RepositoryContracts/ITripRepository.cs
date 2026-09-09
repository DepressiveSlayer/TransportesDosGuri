using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllAsync();

        Task<Trip?> GetByIdAsync(long id);

        Task AddAsync(Trip trip);

        Task UpdateAsync(Trip trip);

        Task DeleteAsync(long id);
    }
}
