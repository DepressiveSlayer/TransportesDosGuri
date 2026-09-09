using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class AsaasIntegrationService : IAsaasIntegrationService
    {
        private readonly IAsaasIntegrationRepository _asaasIntegrationsRepository;

        public AsaasIntegrationService(IAsaasIntegrationRepository asaasIntegrationsRepository)
        {
            _asaasIntegrationsRepository = asaasIntegrationsRepository;
        }

        public async Task<AsaasIntegrationDTO> CreateAsync(AsaasIntegrationDTO asaasIntegration)
        {
            var asaasIntegrationEntity = new AsaasIntegration
            {
                Environment = asaasIntegration.Environment,
                ApiKey = asaasIntegration.ApiKey,
                BaseUrl = asaasIntegration.BaseUrl,
                IsActive = asaasIntegration.IsActive
            };

            await _asaasIntegrationsRepository.AddAsync(asaasIntegrationEntity);

            asaasIntegration.Id = asaasIntegrationEntity.Id;

            return asaasIntegration;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var asaasIntegrationEntity = await _asaasIntegrationsRepository.GetByIdAsync(id);

            if (asaasIntegrationEntity == null)
            {
                return false;
            }

            await _asaasIntegrationsRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<AsaasIntegrationDTO>> GetAllAsync()
        {
            var asaasIntegrationEntities = await _asaasIntegrationsRepository.GetAllAsync();

            return asaasIntegrationEntities.Select(asaasIntegrationEntities => new AsaasIntegrationDTO
            {
                Id = asaasIntegrationEntities.Id,
                Environment = asaasIntegrationEntities.Environment,
                BaseUrl = asaasIntegrationEntities.BaseUrl,
                IsActive = asaasIntegrationEntities.IsActive
            });
        }

        public async Task<AsaasIntegrationDTO?> GetByIdAsync(long id)
        {
            var asaasIntegrationEntity = await _asaasIntegrationsRepository.GetByIdAsync(id);

            if (asaasIntegrationEntity == null)
            {
                return null;
            }

            return new AsaasIntegrationDTO
            {
                Id = asaasIntegrationEntity.Id,
                Environment = asaasIntegrationEntity.Environment,
                BaseUrl = asaasIntegrationEntity.BaseUrl,
                IsActive = asaasIntegrationEntity.IsActive
            };
        }

        public async Task<bool> UpdateAsync(long id, AsaasIntegrationDTO asaasIntegration)
        {
            var existingAsaasIntegration = await _asaasIntegrationsRepository.GetByIdAsync(id);

            if (existingAsaasIntegration == null)
            {
                return false;
            }

            existingAsaasIntegration.Environment = asaasIntegration.Environment;
            existingAsaasIntegration.BaseUrl = asaasIntegration.BaseUrl;
            existingAsaasIntegration.IsActive = asaasIntegration.IsActive;

            await _asaasIntegrationsRepository.UpdateAsync(existingAsaasIntegration);

            return true;
        }
    }
}
