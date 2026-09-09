namespace TransportesDosGuri.Core.Application.DTOs.Identity
{
    public class UserProfileResponseDTO
    {
        public long Id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? IdentityNumber { get; set; } = string.Empty;

        public string? CustomerAsaasId { get; set; }

        public string? ZipCode { get; set; }

        public string? Address { get; set; }

        public int AddressNumber { get; set; }

        public string? District { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }
    }
}
