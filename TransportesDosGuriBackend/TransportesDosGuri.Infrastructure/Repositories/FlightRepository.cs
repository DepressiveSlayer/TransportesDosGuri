using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public FlightRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Flight flight)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Flight
                (
                    AircraftId,
                    OriginAirportId,
                    DestinyAirportId,
                    DepartureTime,
                    ArrivalTime,
                    BasePrice,
                    TripId
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @AircraftId,
                    @OriginAirportId,
                    @DestinyAirportId,
                    @DepartureTime,
                    @ArrivalTime,
                    @BasePrice,
                    @TripId
                );
                """;

            flight.Id = await connection.ExecuteScalarAsync<long>(sql, flight);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Flight
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    AircraftId,
                    OriginAirportId,
                    DestinyAirportId,
                    DepartureTime,
                    ArrivalTime,
                    BasePrice,
                    TripId
                FROM Flight
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Flight>(sql);
        }

        public async Task<Flight?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    AircraftId,
                    OriginAirportId,
                    DestinyAirportId,
                    DepartureTime,
                    ArrivalTime,
                    BasePrice,
                    TripId
                FROM Flight
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Flight>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Flight flight)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Flight
                SET
                    AircraftId = @AircraftId,
                    OriginAirportId = @OriginAirportId,
                    DestinyAirportId = @DestinyAirportId,
                    DepartureTime = @DepartureTime,
                    ArrivalTime = @ArrivalTime,
                    BasePrice = @BasePrice,
                    TripId = @TripId
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, flight);
        }
    }
}
