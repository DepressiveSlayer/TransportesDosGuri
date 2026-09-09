using Dapper;
using TransportesDosGuri.Core.Domain.Entities;
using TransportesDosGuri.Core.Domain.RepositoryContracts;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PurchaseRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAsync(Purchase purchase)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                INSERT INTO Purchase
                (
                    ApplicationUserId,
                    PurchaseDate,
                    PurchasePrice,
                    Status
                )
                OUTPUT INSERTED.Id
                VALUES
                (
                    @ApplicationUserId,
                    @PurchaseDate,
                    @PurchasePrice,
                    @Status
                );
                """;

            purchase.Id = await connection.ExecuteScalarAsync<long>(sql, purchase);
        }

        public async Task DeleteAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                DELETE FROM Purchase
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    ApplicationUserId,
                    PurchaseDate,
                    PurchasePrice,
                    Status
                FROM Purchase
                ORDER BY Id DESC;
                """;

            return await connection.QueryAsync<Purchase>(sql);
        }

        public async Task<Purchase?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                SELECT
                    Id,
                    ApplicationUserId,
                    PurchaseDate,
                    PurchasePrice,
                    Status
                FROM Purchase
                WHERE Id = @Id;
                """;

            return await connection.QueryFirstOrDefaultAsync<Purchase>(sql, new { Id = id });
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
                UPDATE Purchase
                SET
                    ApplicationUserId = @ApplicationUserId,
                    PurchaseDate = @PurchaseDate,
                    PurchasePrice = @PurchasePrice,
                    Status = @Status
                WHERE Id = @Id;
                """;

            await connection.ExecuteAsync(sql, purchase);
        }
    }
}
