namespace TransportesDosGuri.Core.Domain.Entities
{
    public class UserRequest
    {
        public long Id { get; set; }

        public decimal Price { get; set; }

        public DateOnly DueDate { get; set; }

        public long ApplicationUserId { get; set; }

        public string? AsaasSubscriptionId { get; set; }

    }
}
