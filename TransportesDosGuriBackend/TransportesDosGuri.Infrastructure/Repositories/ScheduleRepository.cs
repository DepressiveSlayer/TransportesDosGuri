using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ScheduleRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Schedule schedule)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Schedule
                (
                    FlightId,
                    AirportId,
                    DepartureTime,
                    ArrivalTime
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @FlightId,
                    @AirportId,
                    @DepartureTime,
                    @ArrivalTime
                );
                """;

            schedule.Id = await connection.ExecuteScalarAsync<long>(sql, schedule);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Schedule
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    FlightId,
                    AirportId,
                    DepartureTime,
                    ArrivalTime
                FROM Schedule
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Schedule>(sql);
        }

        public async Task<Schedule?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    FlightId,
                    AirportId,
                    DepartureTime,
                    ArrivalTime
                FROM Schedule
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Schedule>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Schedule schedule)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Schedule
                SET
                    FlightId = @FlightId,
                    AirportId = @AirportId,
                    DepartureTime = @DepartureTime,
                    ArrivalTime = @ArrivalTime
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, schedule);
        }
    }
}
