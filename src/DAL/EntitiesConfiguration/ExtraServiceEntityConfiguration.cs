using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class ExtraServiceEntityConfiguration : IEntityTypeConfiguration<ExtraServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ExtraServiceEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Title)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(s => s.MaximumAmountInBooking)
                .IsRequired();

            builder.Property(s => s.IsAvailable)
                .IsRequired();

            builder.HasOne(s => s.BookingPoint)
                .WithMany(b => b.ExtraServices)
                .HasForeignKey(s => s.BookingPointId);
        }
    }
}