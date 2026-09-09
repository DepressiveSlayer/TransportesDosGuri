using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransportesDosGuri.Core.Domain.Entities.Identity;

namespace TransportesDosGuri.Infrastructure.IdentityContext
{
    public class ApplicationUserDbContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        long,
        IdentityUserClaim<long>,
        IdentityUserRole<long>,
        IdentityUserLogin<long>,
        IdentityRoleClaim<long>,
        IdentityUserToken<long>>
    {
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(100);
                entity.Property(u => u.LastName).HasMaxLength(100);
                entity.Property(u => u.IdentityNumber).HasMaxLength(50);
                entity.Property(u => u.ZipCode).HasMaxLength(20);
                entity.Property(u => u.Address).HasMaxLength(256);
                entity.Property(u => u.District).HasMaxLength(100);
                entity.Property(u => u.City).HasMaxLength(100);
                entity.Property(u => u.State).HasMaxLength(50);
                entity.Property(u => u.CustomerAsaasId).HasMaxLength(100);
                entity.Property(u => u.RefreshToken);
                entity.Property(u => u.RefreshTokenExpirationDateTime);
            });
        }


    }
}
