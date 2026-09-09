using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class AircraftRepository : IAircraftRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AircraftRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Aircraft aircraft)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Aircraft
                (
                    Type,
                    Model
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Type,
                    @Model
                );
                """;

            aircraft.Id = await connection.ExecuteScalarAsync<long>(sql, aircraft);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Aircraft
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Aircraft>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    Type,
                    Model
                FROM Aircraft
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Aircraft>(sql);
        }

        public async Task<Aircraft?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    Type,
                    Model
                FROM Aircraft
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Aircraft>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Aircraft aircraft)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Aircraft
                SET
                    Type = @Type,
                    Model = @Model
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, aircraft);
        }
    }
}
