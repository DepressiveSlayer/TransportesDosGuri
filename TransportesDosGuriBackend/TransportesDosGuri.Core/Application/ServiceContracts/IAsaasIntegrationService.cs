using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IAsaasIntegrationService
    {
        Task<IEnumerable<AsaasIntegrationDTO>> GetAllAsync();

        Task<AsaasIntegrationDTO?> GetByIdAsync(long id);

        Task<AsaasIntegrationDTO> CreateAsync(AsaasIntegrationDTO asaasIntegration);

        Task<bool> UpdateAsync(long id, AsaasIntegrationDTO asaasIntegration);

        Task<bool> DeleteAsync(long id);
    }
}
