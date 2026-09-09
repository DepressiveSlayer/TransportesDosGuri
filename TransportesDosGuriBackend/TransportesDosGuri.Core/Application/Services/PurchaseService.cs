using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;

namespace TransportesDosGuri.Core.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<PurchaseDTO> CreateAsync(PurchaseDTO purchase)
        {
            var purchaseEntity = new Purchase
            {
                ApplicationUserId = purchase.ApplicationUserId,
                PurchaseDate = purchase.PurchaseDate,
                PurchasePrice = purchase.PurchasePrice,
                Status = purchase.Status
            };

            await _purchaseRepository.AddAsync(purchaseEntity);

            purchase.Id = purchaseEntity.Id;

            return purchase;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var purchaseEntity = await _purchaseRepository.GetByIdAsync(id);

            if (purchaseEntity == null)
            {
                return false;
            }

            await _purchaseRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<PurchaseDTO>> GetAllAsync()
        {
            var purchaseEntities = await _purchaseRepository.GetAllAsync();

            return purchaseEntities.Select(purchaseEntities => new PurchaseDTO
            {
                Id = purchaseEntities.Id,
                ApplicationUserId = purchaseEntities.ApplicationUserId,
                PurchaseDate = purchaseEntities.PurchaseDate,
                PurchasePrice = purchaseEntities.PurchasePrice,
                Status = purchaseEntities.Status
            });
        }

        public async Task<PurchaseDTO?> GetByIdAsync(long id)
        {
            var purchaseEntity = await _purchaseRepository.GetByIdAsync(id);

            if (purchaseEntity == null)
            {
                return null;
            }

            return new PurchaseDTO
            {
                Id = purchaseEntity.Id,
                ApplicationUserId = purchaseEntity.ApplicationUserId,
                PurchaseDate = purchaseEntity.PurchaseDate,
                PurchasePrice = purchaseEntity.PurchasePrice,
                Status = purchaseEntity.Status
            };
        }

        public async Task<bool> UpdateAsync(long id, PurchaseDTO purchase)
        {
            var existingPurchase = await _purchaseRepository.GetByIdAsync(id);

            if (existingPurchase == null)
            {
                return false;
            }

            existingPurchase.ApplicationUserId = purchase.ApplicationUserId;
            existingPurchase.PurchaseDate = purchase.PurchaseDate;
            existingPurchase.PurchasePrice = purchase.PurchasePrice;
            existingPurchase.Status = purchase.Status;

            await _purchaseRepository.UpdateAsync(existingPurchase);

            return true;
        }
    }
}
