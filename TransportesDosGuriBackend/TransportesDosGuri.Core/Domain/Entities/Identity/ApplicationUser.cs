using Microsoft.AspNetCore.Identity;

namespace TransportesDosGuri.Core.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? IdentityNumber { get; set; }

        public string? ZipCode { get; set; }

        public string? Address { get; set; }

        public int AddressNumber { get; set; }

        public string? District { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string FullName => $"{Name} {LastName}";

        public string? CustomerAsaasId { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpirationDateTime { get; set; }
    }
}
