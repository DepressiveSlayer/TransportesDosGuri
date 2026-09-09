using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllAsync();

        Task<Reservation?> GetByIdAsync(long id);

        Task AddAsync(Reservation reservation);

        Task UpdateAsync(Reservation reservation);

        Task DeleteAsync(long id);
    }
}
