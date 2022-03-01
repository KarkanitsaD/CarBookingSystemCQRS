using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class CarLockEntityConfiguration : IEntityTypeConfiguration<CarLockEntity>
    {
        public void Configure(EntityTypeBuilder<CarLockEntity> builder)
        {
            builder.HasKey(l => new { l.CarId, l.UserId });

            builder.HasOne(l => l.Car)
                .WithOne(c => c.CarLock)
                .HasForeignKey<CarLockEntity>(l => l.CarId);

            builder.HasOne(l => l.User)
                .WithOne(u => u.CarLock)
                .HasForeignKey<CarLockEntity>(l => l.UserId);

            builder.Property(l => l.ExpirationTime)
                .IsRequired();
        }
    }
}