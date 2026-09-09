using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllAsync();

        Task<Flight?> GetByIdAsync(long id);

        Task AddAsync(Flight flight);

        Task UpdateAsync(Flight flight);

        Task DeleteAsync(long id);
    }
}
