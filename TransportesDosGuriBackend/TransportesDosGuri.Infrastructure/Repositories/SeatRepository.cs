using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {

        private readonly IDbConnectionFactory _connectionFactory;

        public SeatRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Seat seat)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Seat
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

            seat.Id = await connection.ExecuteScalarAsync<long>(sql, seat);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Seat
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
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
                FROM Seat
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Seat>(sql);
        }

        public async Task<Seat?> GetByIdAsync(long id)
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
                FROM Seat
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Seat>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Seat seat)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Seat
                SET
                    AircraftId = @AircraftId,
                    SeatNumber = @SeatNumber,
                    Class = @Class,
                    Location = @Location,
                    Side = @Side
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, seat);
        }
    }
}
