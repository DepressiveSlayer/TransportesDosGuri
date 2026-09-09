using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<Purchase>> GetAllAsync();

        Task<Purchase?> GetByIdAsync(long id);

        Task AddAsync(Purchase purchase);

        Task UpdateAsync(Purchase purchase);

        Task DeleteAsync(long id);
    }
}
