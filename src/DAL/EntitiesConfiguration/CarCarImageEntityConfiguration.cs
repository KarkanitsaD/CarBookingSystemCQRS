using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class CarCarImageEntityConfiguration : IEntityTypeConfiguration<CarCarImageEntity>
    {
        public void Configure(EntityTypeBuilder<CarCarImageEntity> builder)
        {
            builder.HasKey(b => new { b.CarId, b.CarImageId });

            builder.HasOne(b => b.Car)
                .WithMany(c => c.CarCarImages)
                .HasForeignKey(b => b.CarId);

            builder.HasOne(b => b.CarImage)
                .WithMany(i => i.CarImageCars)
                .HasForeignKey(b => b.CarImageId);
        }
    }
}