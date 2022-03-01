using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntitiesConfiguration
{
    public class CarImageEntityConfiguration : IEntityTypeConfiguration<CarImageEntity>
    {
        public void Configure(EntityTypeBuilder<CarImageEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Extension)
                .IsRequired();

            builder.Property(i => i.Content)
                .IsRequired();
        }
    }
}