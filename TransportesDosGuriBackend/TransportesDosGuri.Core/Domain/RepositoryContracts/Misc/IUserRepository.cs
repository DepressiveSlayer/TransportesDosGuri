using TransportesDosGuri.Core.Domain.Entities.Identity;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts.Misc
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(long id);
        Task UpdateAsaasCustomerIdAsync(long userId, string customerId);
    }
}
