using TransportesDosGuri.Core.Domain.Entities;

namespace TransportesDosGuri.Core.Domain.RepositoryContracts
{
    public interface IFlightSeatRepository
    {
        Task<IEnumerable<FlightSeat>> GetAllAsync();

        Task<FlightSeat?> GetByIdAsync(long id);

        Task AddAsync(FlightSeat flightSeat);

        Task UpdateAsync(FlightSeat flightSeat);

        Task DeleteAsync(long id);
    }
}
