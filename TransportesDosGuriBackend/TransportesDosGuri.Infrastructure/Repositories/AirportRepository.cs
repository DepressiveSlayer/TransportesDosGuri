using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AirportRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Airport>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    Name,
                    City,
                    State,
                    Country
                FROM Airport
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Airport>(sql);
        }

        public async Task<Airport?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    Name,
                    City,
                    State,
                    Country
                FROM Airport
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Airport>(sql, new { Id = id });
        }

        public async Task AddAsync(Airport airport)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Airport
                (
                    Name,
                    City,
                    State,
                    Country
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Name,
                    @City,
                    @State,
                    @Country
                );
                """;

            airport.Id = await connection.ExecuteScalarAsync<long>(sql, airport);
        }

        public async Task UpdateAsync(Airport airport)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Airport
                SET
                    Name = @Name,
                    City = @City,
                    State = @State,
                    Country = @Country
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, airport);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Airport
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

    }
}
