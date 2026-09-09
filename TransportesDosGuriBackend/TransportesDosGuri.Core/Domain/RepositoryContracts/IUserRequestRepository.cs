using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IUserRequestRepository
    {
        Task<IEnumerable<UserRequest>> GetAllAsync();

        Task<UserRequest?> GetByIdAsync(long id);

        Task AddAsync(UserRequest userRequest);

        Task UpdateAsync(UserRequest userRequest);

        Task DeleteAsync(long id);
    }
}
