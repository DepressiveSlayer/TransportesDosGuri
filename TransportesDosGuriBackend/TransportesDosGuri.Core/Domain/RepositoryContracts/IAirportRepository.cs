using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAllAsync();

        Task<Airport?> GetByIdAsync(long id);

        Task AddAsync(Airport airport);

        Task UpdateAsync(Airport airport);

        Task DeleteAsync(long id);
    }
}
