using Dapper;
using TransportesDosGuri.Core.Domain.Entities.Identity;
using TransportesDosGuri.Core.Domain.RepositoryContracts.Misc;
using TransportesDosGuri.Infrastructure.Data;

namespace TransportesDosGuri.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ApplicationUser?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = "SELECT * FROM AspNetUsers WHERE Id = @Id;";
            return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(sql, new { Id = id });
        }

        public async Task UpdateAsaasCustomerIdAsync(long userId, string customerId)
        {
            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                UPDATE AspNetUsers 
                SET CustomerAsaasId = @CustomerId 
                WHERE Id = @UserId;
                """;
            await connection.ExecuteAsync(sql, new { UserId = userId, CustomerId = customerId });
        }
    }
}
