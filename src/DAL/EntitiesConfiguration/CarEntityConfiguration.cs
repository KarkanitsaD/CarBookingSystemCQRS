using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.Property(c => c.PricePerDay)
                .IsRequired();

            builder.Property(c => c.Brand)
                .IsRequired();

            builder.Property(c => c.Model)
                .IsRequired();

            builder.Property(c => c.FuelConsumption)
                .IsRequired();

            builder.Property(c => c.NumberOfSeats)
                .IsRequired();

            builder.HasOne(c => c.Transmission)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.CarTransmissionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.BookingPoint)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BookingPointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}