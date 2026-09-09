using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TripRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Trip trip)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Trip
                (
                    TripName,
                    OriginAirportId,
                    DestinyAirportId,
                    DepartureTime,
                    ArrivalTime,
                    TotalPrice
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @TripName,
                    @OriginAirportId,
                    @DestinyAirportId,
                    @DepartureTime,
                    @ArrivalTime,
                    @TotalPrice
                );
                """;

            trip.Id = await connection.ExecuteScalarAsync<long>(sql, trip);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Trip
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    TripName,
                    OriginAirportId,
                    DestinyAirportId,
                    DepartureTime,
                    ArrivalTime,
                    TotalPrice
                FROM Trip
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Trip>(sql);
        }

        public async Task<Trip?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    TripName,
                    OriginAirportId,
                    DestinyAirportId,
                    DepartureTime,
                    ArrivalTime,
                    TotalPrice
                FROM Trip
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Trip>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Trip trip)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Trip
                SET
                    TripName = @TripName,
                    OriginAirportId = @OriginAirportId,
                    DestinyAirportId = @DestinyAirportId,
                    DepartureTime = @DepartureTime,
                    ArrivalTime = @ArrivalTime,
                    TotalPrice = @TotalPrice
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, trip);
        }
    }
}
