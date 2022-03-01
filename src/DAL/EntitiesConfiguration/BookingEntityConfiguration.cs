using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Price)
                .IsRequired();

            builder.Property(b => b.BookingTime)
                .IsRequired();

            builder.Property(b => b.PickUpTime)
                .IsRequired();

            builder.Property(b => b.HandOverTime)
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Surname)
                .IsRequired();

            builder.Property(b => b.Email)
                .IsRequired();

            builder.Property(b => b.PhoneNumber)
                .IsRequired();

            builder.HasOne(b => b.Car)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CarId);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);
        }
    }
}