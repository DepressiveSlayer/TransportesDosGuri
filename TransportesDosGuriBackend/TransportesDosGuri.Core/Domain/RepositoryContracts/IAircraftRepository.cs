using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IAircraftRepository
    {
        Task<IEnumerable<Aircraft>> GetAllAsync();

        Task<Aircraft?> GetByIdAsync(long id);

        Task AddAsync(Aircraft aircraft);

        Task UpdateAsync(Aircraft aircraft);

        Task DeleteAsync(long id);
    }
}
