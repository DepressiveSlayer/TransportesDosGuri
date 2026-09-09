using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IAsaasIntegrationRepository
    {
        Task<IEnumerable<AsaasIntegration>> GetAllAsync();

        Task<AsaasIntegration?> GetByIdAsync(long id);

        Task AddAsync(AsaasIntegration asaasIntegration);

        Task UpdateAsync(AsaasIntegration asaasIntegration);

        Task DeleteAsync(long id);

        Task<AsaasIntegration?> GetActiveAsync();
    }
}
