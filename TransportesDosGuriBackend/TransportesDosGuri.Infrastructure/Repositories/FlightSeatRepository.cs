using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class FlightSeatRepository : IFlightSeatRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public FlightSeatRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(FlightSeat flightSeat)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO FlightSeat
                (
                    AircraftId,
                    SeatNumber,
                    Class,
                    Location,
                    Side
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @AircraftId,
                    @SeatNumber,
                    @Class,
                    @Location,
                    @Side
                );
                """;

            flightSeat.Id = await connection.ExecuteScalarAsync<long>(sql, flightSeat);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM FlightSeat
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<FlightSeat>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    AircraftId,
                    SeatNumber,
                    Class,
                    Location,
                    Side
                FROM FlightSeat
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<FlightSeat>(sql);
        }

        public async Task<FlightSeat?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    AircraftId,
                    SeatNumber,
                    Class,
                    Location,
                    Side
                FROM FlightSeat
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<FlightSeat>(sql, new { Id = id });
        }

        public async Task UpdateAsync(FlightSeat flightSeat)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE FlightSeat
                SET
                    AircraftId = @AircraftId,
                    SeatNumber = @SeatNumber,
                    Class = @Class,
                    Location = @Location
                    Side = @Side
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, flightSeat);
        }
    }
}
