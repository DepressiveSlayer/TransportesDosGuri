namespace TransportesDosGuri.Core.Domain.Entities
{
    public class AsaasIntegration
    {
        public long Id { get; set; }

        public string? Environment { get; set; }

        public string? ApiKey { get; set; }

        public string? BaseUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
