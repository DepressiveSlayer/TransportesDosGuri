using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class AsaasIntegrationRepository : IAsaasIntegrationRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AsaasIntegrationRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(AsaasIntegration asaasIntegration)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO AsaasIntegration
                (
                    Environment,
                    ApiKey,
                    BaseUrl,
                    IsActive
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @Environment,
                    @ApiKey,
                    @BaseUrl,
                    @IsActive
                );
                """;

            asaasIntegration.Id = await connection.ExecuteScalarAsync<long>(sql, asaasIntegration);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM AsaasIntegration
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<AsaasIntegration?> GetActiveAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT TOP 1
                    Id,
                    Environment,
                    ApiKey,
                    BaseUrl,
                    IsActive
                FROM AsaasIntegration
                WHERE IsActive = 1;
                """;

            return await connection.QueryFirstOrDefaultAsync<AsaasIntegration>(sql);
        }

        public async Task<IEnumerable<AsaasIntegration>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    Environment,
                    ApiKey,
                    BaseUrl,
                    IsActive
                FROM AsaasIntegration
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<AsaasIntegration>(sql);
        }

        public async Task<AsaasIntegration?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    Environment,
                    ApiKey,
                    BaseUrl,
                    IsActive
                FROM AsaasIntegration
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<AsaasIntegration>(sql, new { Id = id });
        }

        public async Task UpdateAsync(AsaasIntegration asaasIntegration)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE AsaasIntegration
                SET
                    Environment = @Environment,
                    ApiKey = @ApiKey,
                    BaseUrl = @BaseUrl,
                    IsActive = @IsActive
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, asaasIntegration);
        }
    }
}
