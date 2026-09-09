namespace TransportesDosGuri.Core.Application.DTOs.Asaas
{
    public class AsaasPaymentRequestDTO
    {
        public string Customer { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string DueDate { get; set; } = string.Empty;
        public string BillingType { get; set; } = "BOLETO";
        public string? Description { get; set; }
    }
}
