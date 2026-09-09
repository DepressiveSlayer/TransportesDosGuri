using TransportesDosGuri.Core.Application.DTOs;

namespace TransportesDosGuri.Core.Application.ServiceContracts
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseDTO>> GetAllAsync();

        Task<PurchaseDTO?> GetByIdAsync(long id);

        Task<PurchaseDTO> CreateAsync(PurchaseDTO purchase);

        Task<bool> UpdateAsync(long id, PurchaseDTO purchase);

        Task<bool> DeleteAsync(long id);
    }
}
