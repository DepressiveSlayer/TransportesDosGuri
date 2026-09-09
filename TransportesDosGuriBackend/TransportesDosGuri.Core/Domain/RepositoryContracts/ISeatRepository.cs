using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllAsync();

        Task<Seat?> GetByIdAsync(long id);

        Task AddAsync(Seat seat);

        Task UpdateAsync(Seat seat);

        Task DeleteAsync(long id);
    }
}
