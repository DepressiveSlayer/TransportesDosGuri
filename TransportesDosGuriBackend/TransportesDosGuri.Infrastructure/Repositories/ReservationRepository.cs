using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ReservationRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Reservation reservation)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Reservation
                (
                    ApplicationUserId,
                    FlightSeatId,
                    PurchaseId,
                    ReservationDate,
                    Status,
                    Price
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @ApplicationUserId,
                    @FlightSeatId,
                    @PurchaseId,
                    @ReservationDate,
                    @Status,
                    @Price
                );
                """;

            reservation.Id = await connection.ExecuteScalarAsync<long>(sql, reservation);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Reservation
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    ApplicationUserId,
                    FlightSeatId,
                    PurchaseId,
                    ReservationDate,
                    Status,
                    Price
                FROM Reservation
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Reservation>(sql);
        }

        public async Task<Reservation?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    ApplicationUserId,
                    FlightSeatId,
                    PurchaseId,
                    ReservationDate,
                    Status,
                    Price
                FROM Reservation
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Reservation>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Reservation
                SET
                    ApplicationUserId = @ApplicationUserId,
                    FlightSeatId = @FlightSeatId,
                    PurchaseId = @PurchaseId,
                    ReservationDate = @ReservationDate,
                    Status = @Status,
                    Price = @Price
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, reservation);
        }
    }
}
