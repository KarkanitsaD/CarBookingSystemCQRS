using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class CarTransmissionEntityConfiguration : IEntityTypeConfiguration<CarTransmissionEntity>
    {
        public void Configure(EntityTypeBuilder<CarTransmissionEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired();
        }
    }
}