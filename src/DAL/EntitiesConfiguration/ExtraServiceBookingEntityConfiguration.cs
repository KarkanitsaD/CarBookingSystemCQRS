using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class ExtraServiceBookingEntityConfiguration : IEntityTypeConfiguration<ExtraServiceBookingEntity>
    {
        public void Configure(EntityTypeBuilder<ExtraServiceBookingEntity> builder)
        {
            builder.HasKey(b => new { b.BookingId, b.ExtraServiceId });

            builder.HasOne(b => b.Booking)
                .WithMany(b => b.BookingExtraServices)
                .HasForeignKey(b => b.BookingId);

            builder.HasOne(b => b.ExtraService)
                .WithMany(s => s.ExtraServiceBookings)
                .HasForeignKey(b => b.ExtraServiceId);

            builder.Property(b => b.Amount)
                .IsRequired();
        }
    }
}