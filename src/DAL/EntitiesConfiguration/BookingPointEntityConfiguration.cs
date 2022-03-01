using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class BookingPointEntityConfiguration : IEntityTypeConfiguration<BookingPointEntity>
    {
        public void Configure(EntityTypeBuilder<BookingPointEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Address)
                .IsRequired();

            builder.Property(b => b.Title)
                .IsRequired();

            builder.HasOne(b => b.City)
                .WithMany(c => c.BookingPoints)
                .HasForeignKey(b => b.CityId);
        }
    }
}