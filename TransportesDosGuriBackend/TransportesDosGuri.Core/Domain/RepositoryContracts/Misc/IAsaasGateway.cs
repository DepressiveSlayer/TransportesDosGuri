namespace TransportesDosGuri.Core.Domain.RepositoryContracts.Misc
{
    public interface IAsaasGateway
    {
        Task<string> CreateCustomerAsync(string name, string email, string phone, string cpfCnpj);
        Task<string> CreateSinglePaymentAsync(string customerId, decimal amount, DateOnly dueDate);
    }

}

